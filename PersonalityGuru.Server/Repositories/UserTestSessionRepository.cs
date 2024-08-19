using PersonalityGuru.Server.Data;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Repositories
{
    public class UserTestSessionRepository: IUserTestSessionRepository
    {
        private readonly ApplicationDbContext appDbContext;
        public UserTestSessionRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<UserTestSession> StartUserTestSessionAsync(string userId, int questionnaireId)
        {
            UserTestSession testSession = new(userId, questionnaireId);
            await appDbContext.UserTestSessions.AddAsync(testSession);
            await appDbContext.SaveChangesAsync();
            return testSession;
        }

        public async Task<UserTestSession> GetTestSessionAsync(Guid testSessionId)
        {
            return await appDbContext.UserTestSessions.FindAsync(testSessionId);
        }

        public async Task CompleteUserTestSessionAsync(UserTestSession userTestSession)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserTestAnswer>> GetUserAnswers(Guid testSessionId)
        {
            List<UserTestAnswer> answers = appDbContext.UserTestAnswers.Where(a => a.UserTestSessionId == testSessionId).ToList();
            return answers;
        }

        public async Task StoreUserAnswer(Guid testSessionId, int questionId, AnswerOption answer)
        {
            UserTestAnswer testAnswer = new UserTestAnswer
            {
                UserTestSessionId = testSessionId,
                QuestionId = questionId,
                AnswerOption = answer
            };
            await appDbContext.UserTestAnswers.AddAsync(testAnswer);
            await appDbContext.SaveChangesAsync();
        }
    }
}
