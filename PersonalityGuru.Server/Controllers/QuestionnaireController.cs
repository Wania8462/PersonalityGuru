using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Shared.Models;
using PersonalityGuru.Shared.Repository;

namespace PersonalityGuru.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireRepository questionnaireRepository;
        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            this.questionnaireRepository = questionnaireRepository;
        }

        [RequireHttpsGet("{id}")]
        public async Task<Questionnaire> GetQuestionnaireAsync(int id)
        {
            return await questionnaireRepository.GetQuestionnaireAsync(id);
        }

        [HttpPost("{id}")]
        [DisableCors]
        public async Task<UserState> StartQuestionnaire(int id)
        {
            UserState state = new(HttpContext.User.Identity?.Name);
            Questionnaire questionnaire = await GetQuestionnaireAsync(id);
            state.StartTest(questionnaire);
            return state;
        }
    }

    public class RequireHttpsGetAttribute : Attribute
    {
        public RequireHttpsGetAttribute(string id)
        {
            throw new NotImplementedException();
        }
    }
}
