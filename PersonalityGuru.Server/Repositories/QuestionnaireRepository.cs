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

        public async Task<List<SavedUserAnswers>> GetAllUserAnswersAsync(string userId, int questionnaireId)
        {
            return new List<SavedUserAnswers>();
            // return await appDbContext.UserAnswers
            //     .Where(ua => ua.UserId == userId && ua.QuestionnaireId == questionnaireId)
            //     .ToListAsync();
        }

        public Task<SavedUserAnswers?> GetLastUserAnswersAsync(string userId, int questionnaireId)
        {
            return null;
            // return appDbContext.UserAnswers
            //     .Where(ua => ua.UserId == userId && ua.QuestionnaireId == questionnaireId)
            //     .OrderByDescending(ua => ua.CompletedAt)
            //     .FirstOrDefaultAsync();
        }
    }
}
