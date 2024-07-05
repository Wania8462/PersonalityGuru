using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Shared.Models;
using PersonalityGuru.Shared.Repository;

namespace PersonalityGuru.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireRepository questionnaireRepository;
        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            this.questionnaireRepository = questionnaireRepository;
        }

        [HttpGet("{id}")]
        public async Task<Questionnaire> GetQuestionnaireAsync(int id)
        {
            return await questionnaireRepository.GetQuestionnaireAsync(id);
        }

        [HttpPost("{id}/start")]
        public async Task<UserState> StartQuestionnaire(int id)
        {
            UserState state = new UserState(HttpContext.User.Identity?.Name);
            Questionnaire questionnaire = await GetQuestionnaireAsync(id);
            state.StartTest(questionnaire);
            return state;
        }
    }
}
