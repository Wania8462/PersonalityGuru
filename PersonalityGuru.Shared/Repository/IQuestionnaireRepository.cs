using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Shared.Repository
{
    public interface IQuestionnaireRepository
    {
        Task<Questionnaire> GetQuestionnaireAsync(int id);
    }
}
