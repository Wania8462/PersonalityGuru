using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Shared.Models;

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

            // Testing
            //List<UserTestAnswer> answers = userTestAnswers
            //    .Include(ua => ua.UserTestSession)
            //    .Where(ua => ua.UserTestSession.CompletedAt == lastTime).ToList();

            //List<int> ids = new List<int>();

            //foreach (UserTestAnswer answer in answers)
            //{
            //    ids.Add(answer.QuestionId);
            //}

            //ids.Sort();

            Questionnaire questionnaire = await GetQuestionnaireAsync(questionnaireId);
            Dictionary<string, double> result = [];
            result.Add("O", 0);
            result.Add("К", 0);
            result.Add("Э", 0);
            result.Add("А", 0);
            result.Add("Н", 0);

            foreach (KeyValuePair<int, AnswerOption> answer in answers)
            {
                Question question = questionnaire.Questions.First(q => q.Id == answer.Key);
                result[question.Group] += (int)answer.Value;
            }

            foreach (string key in result.Keys)
            {
                result[key] /= 15;
                result[key] = Math.Round(result[key], 1);
            }

            return new SavedUserAnswers(userId, questionnaireId, result);
        }
    }
}
