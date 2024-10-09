using PersonalityGuru.Server.Data;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Repositories;

public interface IQuestionnaireRepository
{
    Task<Questionnaire> GetQuestionnaireAsync(int id);

    Task SaveUserAnswersAsync(SavedUserAnswers answers);

    Task<SavedUserAnswers?> GetLastUserAnswersAsync(string userId, int questionnaireId);

    Task<List<SavedUserAnswers>> GetAllUserAnswersAsync(string userId, int questionnaireId);
}
