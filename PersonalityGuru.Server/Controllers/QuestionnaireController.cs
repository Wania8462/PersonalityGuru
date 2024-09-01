using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Server.Repositories;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Controllers
{
    [Route("api/questionnaire")]
    [ApiController]
    [EnableCors]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireRepository questionnaireRepository;

        public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
        {
            this.questionnaireRepository = questionnaireRepository;
        }

        [HttpGet("{questionnaireId}")]
        public async Task<Questionnaire?> StoreUserAnswer(int questionnaireId)
        {
            return await questionnaireRepository.GetQuestionnaireAsync(questionnaireId);
        }
    }
}
