using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Server.Migrations;
using PersonalityGuru.Shared.Models;
using System.Linq;


namespace PersonalityGuru.Server.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly ApplicationDbContext appDbContext;

        private static readonly Dictionary<int, Questionnaire> _cache = new();

        public QuestionnaireRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Questionnaire> GetQuestionnaireAsync(int id)
        {
            if (!_cache.ContainsKey(id))
            {
                var q = await appDbContext.Tests
                        .Include(q => q.Questions)
                        .FirstAsync(t => t.Id == id);
                _cache[id] = q;
            }

            return _cache[id];
        }

        public async Task SaveUserAnswersAsync(SavedUserAnswers answers)
        {
            //await appDbContext.UserAnswers.AddAsync(answers);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<SavedUserAnswers?> GetLastUserAnswersAsync(string userId, int questionnaireId)
        {
            // Getting answers from all time
            IQueryable<UserTestAnswer> userTestAnswers = appDbContext.UserTestAnswers
                .Include(ua => ua.UserTestSession)
                .Where(ua => ua.UserTestSession.UserId == userId
                             && ua.UserTestSession.QuestionnaireId == questionnaireId);

            DateTime? lastTime = userTestAnswers
                .Include(ua => ua.UserTestSession)
                .Max(ua => ua.UserTestSession.CompletedAt);

            if (lastTime == null)
                return null;

            Dictionary<int, AnswerOption> answers = userTestAnswers
                .Include(ua => ua.UserTestSession)
                .Where(ua => ua.UserTestSession.CompletedAt == lastTime)
                .ToDictionary(ua => ua.QuestionId, ua => ua.AnswerOption);

            Questionnaire questionnaire = await GetQuestionnaireAsync(questionnaireId);
            Dictionary<string, double> result = CalculateAnswers(answers, questionnaire);
            return new SavedUserAnswers(userId, questionnaireId, (DateTime)lastTime, result);
        }

        public async Task<List<SavedUserAnswers>> GetAllUserAnswersAsync(string userId, int questionnaireId)
        {
            Questionnaire questionnaire = await GetQuestionnaireAsync(questionnaireId);

            IQueryable<UserTestAnswer> userTestAnswers = appDbContext.UserTestAnswers
                .Include(ua => ua.UserTestSession)
                .Where(ua => ua.UserTestSession.UserId == userId
                             && ua.UserTestSession.QuestionnaireId == questionnaireId);

            Dictionary<DateTime, Dictionary<int, AnswerOption>> times = [];

            foreach (var uta in userTestAnswers)
            {
                DateTime? time = uta.UserTestSession.CompletedAt;
                if (time != null)
                {
                    if (!times.ContainsKey((DateTime)time))
                    {
                        Dictionary<int, AnswerOption> answer = new() { { uta.QuestionId, uta.AnswerOption } };
                        times.Add((DateTime)time, answer);
                    }

                    else
                    {
                        times[(DateTime)time].Add(uta.QuestionId, uta.AnswerOption);
                    }
                }
            }

            List<SavedUserAnswers> result = [];

            foreach(var answers in times)
            {
                SavedUserAnswers sua = new(
                    userId,
                    questionnaireId,
                    answers.Key,
                    CalculateAnswers(answers.Value, questionnaire)
                );

                result.Add(sua);
            }

            return result;
        }

        private Dictionary<string, double> CalculateAnswers(Dictionary<int, AnswerOption> answers, Questionnaire questionnaire)
        {
            Dictionary<string, double> result = [];
            result.Add("O", 0);
            result.Add("К", 0);
            result.Add("Э", 0);
            result.Add("А", 0);
            result.Add("Н", 0);

            foreach (KeyValuePair<int, AnswerOption> answer in answers)
            {
                if (answer.Key > 0)
                {
                    Question question = questionnaire.Questions.First(q => q.Id == answer.Key);
                    result[question.Group] += (int)answer.Value;
                }
            }

            foreach (string key in result.Keys)
            {
                result[key] /= 15;
                result[key] = Math.Round(result[key], 1);
            }

            return result;
        }
    }
}
