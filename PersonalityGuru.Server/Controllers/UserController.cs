﻿using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Shared.Models;
using PersonalityGuru.Shared.Repository;

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
        public async Task<UserState> StartQuestionnaire(string userId, int questionnaireId)
        {
            Questionnaire questionnaire =  await questionnaireRepository.GetQuestionnaireAsync(questionnaireId);
            UserState state = new UserState(userId);
            state.StartTest(questionnaire);
            return state;
        }
    }
}
