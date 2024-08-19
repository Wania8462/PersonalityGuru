﻿using System.Net;
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
        private readonly IUserTestSessionRepository userTestSessionRepository;
        public UserController(
            IQuestionnaireRepository questionnaireRepository,
            IUserTestSessionRepository userTestSessionRepository
        )
        {
            this.questionnaireRepository = questionnaireRepository;
            this.userTestSessionRepository = userTestSessionRepository;
        }

        [HttpPost("{userId}/questionnaire/{questionnaireId}/start")]
        public async Task<string> StartQuestionnaire(string userId, int questionnaireId)
        {
            var session = await userTestSessionRepository.StartUserTestSessionAsync(userId, questionnaireId);
            return session.Id.ToString();
        }

        [HttpPost("{userId}/questionnaire/{testSessionId}/storeAnswer/{questionId}")]
        public async Task StoreUserAnswer(string userId, Guid testSessionId, int questionId, [FromBody] AnswerOption answer)
        {
            await userTestSessionRepository.StoreUserAnswer(testSessionId, questionId, answer);
        }

        [HttpGet("{userId}/questionnaire/{testSessionId}/nextQuestion")]
        public async Task<NextQuestion?> GetNextQuestion(string userId, string testSessionId)
        {
            NextQuestion question = new();
            var id = Guid.Parse(testSessionId);
            var session = await userTestSessionRepository.GetTestSessionAsync(id);
            var answers = await userTestSessionRepository.GetUserAnswers(id);
            Questionnaire questionnaire = await questionnaireRepository.GetQuestionnaireAsync(session.QuestionnaireId);

            if (questionnaire.Questions.Count == answers.Count)
            {
                return null;
            }

            var q = questionnaire.Questions[answers.Count];
            return new NextQuestion
            {
                Id = q.Id,
                Text = q.Text,
                AllQuestionsCount = questionnaire.Questions.Count,
                AnsweredQuestionsCount = answers.Count
            };
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
