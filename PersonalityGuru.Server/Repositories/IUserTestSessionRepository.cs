using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Repositories;

public interface IUserTestSessionRepository
{
    Task<UserTestSession> StartUserTestSessionAsync(string userId, int questionnaireId);

    Task CompleteUserTestSessionAsync(UserTestSession userTestSession);
}
