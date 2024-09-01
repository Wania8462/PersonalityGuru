using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Server.Data;
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
            Dictionary<int, AnswerOption> answers = appDbContext.UserTestAnswers
                .Include(ua => ua.UserTestSession)
                .Where(ua => ua.UserTestSession.UserId == userId && ua.UserTestSession.QuestionnaireId == questionnaireId)
                .ToDictionary(ua => ua.QuestionId, ua => ua.AnswerOption);

            if (answers.Count == 0) {
                return null;
            }

            // TODO:
            // get questionnaire using GetQuestionnaireAsync() method
            // calculate averages for each group
            // update SavedUserAnswers data model to include averages instead of just answers
            return new SavedUserAnswers(userId, questionnaireId, answers);
        }
    }
}
