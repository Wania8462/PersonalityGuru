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
        public QuestionnaireRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Questionnaire> GetQuestionnaireAsync(int id)
        {
            return await appDbContext.Tests
                .Include(q => q.Questions)
                .FirstAsync(t => t.Id == id);
        }

        public async Task SaveUserAnswersAsync(SavedUserAnswers answers)
        {
            //await appDbContext.UserAnswers.AddAsync(answers);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<SavedUserAnswers?> GetLastUserAnswersAsync(string userId, int questionnaireId)
        {
            Dictionary<int, AnswerOption> answerOptions = [];
            List<UserTestAnswer> answers = (List<UserTestAnswer>)appDbContext.UserTestAnswers
                .Where(ua => ua.UserTestSession.UserId == userId && ua.UserTestSession.QuestionnaireId == questionnaireId)
                .ToList();

            foreach (UserTestAnswer answer in answers)
                answerOptions.Add(answer.QuestionId, answer.AnswerOption);

            return new SavedUserAnswers(userId, questionnaireId, answerOptions);
        }

        public async Task<List<SavedUserAnswers>> GetAllUserAnswersAsync(string userId, int questionnaireId)
        {
            return new List<SavedUserAnswers>();
            // return await appDbContext.UserAnswers
            //     .Where(ua => ua.UserId == userId && ua.QuestionnaireId == questionnaireId)
            //     .ToListAsync();
        }
    }
}
