using PersonalityGuru.Server.Data;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Repositories;

public interface IUserTestSessionRepository
{
    Task<UserTestSession> StartUserTestSessionAsync(string userId, int questionnaireId);
    Task<UserTestSession> GetTestSessionAsync(Guid testSessionId);
    Task CompleteUserTestSessionAsync(Guid testSessionIdn);
    Task StoreUserAnswer(Guid testSessionId, int questionId, AnswerOption answer);
    Task<List<UserTestAnswer>> GetUserAnswers(Guid testSessionId);
}
