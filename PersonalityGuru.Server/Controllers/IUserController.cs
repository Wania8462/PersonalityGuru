using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Controllers
{
    public interface IUserController
    {
        Task<List<User>> GetAllUsers(int questionnaireId);
        Task<Results<NotFound, Ok<User>>> GetUserById(string userId, int questionnaireId);

        Task<string> StartQuestionnaire(string userId, int questionnaireId);
        Task StoreUserAnswer(string userId, Guid testSessionId, int questionId, [FromBody] StoreAnswerRequest request);
        Task<NextQuestion?> GetNextQuestion(string userId, string testSessionId);
        Task CompleteQuestionnaire(string userId, string testSessionId);
        Task<Results<NotFound, Ok<SavedUserAnswers>>> GetLastUserAnswers(string userId, int questionnaireId);
        Task<Results<NotFound, Ok<List<SavedUserAnswers>>>> GetAllUserAnswers(string userId, int questionnaireId);
    }
}
