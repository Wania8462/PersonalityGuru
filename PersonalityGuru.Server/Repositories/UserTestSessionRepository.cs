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

        public async Task CompleteUserTestSessionAsync(UserTestSession userTestSession)
        {
            throw new NotImplementedException();
        }
    }
}
