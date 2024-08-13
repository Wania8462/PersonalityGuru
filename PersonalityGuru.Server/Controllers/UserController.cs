using System.Net;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost("{userId}/questionnaire/{testSessionId}/storeAnswer/{questionId}")]
        public async Task StoreUserAnswer(string userId, int testSessionId, int questionId, [FromBody] AnswerOption answer)
        {
            // SavedUserAnswers userAnswers = new(userId, questionnaireId, answers);
            // await questionnaireRepository.SaveUserAnswersAsync(userAnswers);
        }

        [HttpGet("{userId}/questionnaire/{testSessionId}/nextQuestion")]
        public async Task<NextQuestion> GetNextQuestion(string userId, int questionnaireId)
        {
            return new NextQuestion(); // await questionnaireRepository.GetAllUserAnswersAsync(userId, questionnaireId);
        }

        [HttpPost("{userId}/questionnaire/{questionnaireId}/complete")]
        public async Task CompleteQuestionnaire(string userId, int questionnaireId, [FromBody] Dictionary<int, AnswerOption> answers)
        {
            SavedUserAnswers userAnswers = new(userId, questionnaireId, answers);
            await questionnaireRepository.SaveUserAnswersAsync(userAnswers);
        }

        [HttpGet("{userId}/questionnaire/{questionnaireId}/results/last")]
        public async Task<Results<NotFound, Ok<SavedUserAnswers>>> GetLastUserAnswers(string userId, int questionnaireId)
        {
            var lastAnswer = await questionnaireRepository.GetLastUserAnswersAsync(userId, questionnaireId);

            if(lastAnswer == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(lastAnswer);
        }

        [HttpGet("{userId}/questionnaire/{questionnaireId}/results/all")]
        public async Task<List<SavedUserAnswers>> GetAllUserAnswers(string userId, int questionnaireId)
        {
            return await questionnaireRepository.GetAllUserAnswersAsync(userId, questionnaireId);
        }
    }
}
