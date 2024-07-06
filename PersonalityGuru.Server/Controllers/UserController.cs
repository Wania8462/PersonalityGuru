using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Server.Data;
using PersonalityGuru.Server.Repositories;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IQuestionnaireRepository questionnaireRepository;
        public UserController(IQuestionnaireRepository questionnaireRepository)
        {
            this.questionnaireRepository = questionnaireRepository;
        }

        [HttpPost("{userId}/questionnaire/{questionnaireId}/start")]
        public async Task<CurrentQuestionnaire> StartQuestionnaire(string userId, int questionnaireId)
        {
            Questionnaire questionnaire =  await questionnaireRepository.GetQuestionnaireAsync(questionnaireId);
            CurrentQuestionnaire state = new(userId);
            state.StartTest(questionnaire);
            return state;
        }

        [HttpPost("{userId}/questionnaire/{questionnaireId}/complete")]
        public async Task CompleteQuestionnaire(string userId, int questionnaireId, [FromBody] Dictionary<int, AnswerOption> answers)
        {
            SavedUserAnswers userAnswers = new(userId, questionnaireId, answers);
            await questionnaireRepository.SaveUserAnswersAsync(userAnswers);
        }
    }
}
