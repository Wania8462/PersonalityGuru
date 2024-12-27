﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Server.Data;
using PersonalityGuru.Server.Gateways.Email;
using PersonalityGuru.Server.Repositories;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase, IUserController
    {
        private readonly string ResultsBaseUrl = "https://localhost:7165/result";
    
        private readonly IQuestionnaireRepository questionnaireRepository;
        private readonly IUserTestSessionRepository userTestSessionRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEmailGateway emailGateway;

        public UserController(
            IQuestionnaireRepository questionnaireRepository,
            IUserTestSessionRepository userTestSessionRepository,
            IUsersRepository usersRepository,
            IEmailGateway emailGateway
        )
        {
            this.questionnaireRepository = questionnaireRepository;
            this.userTestSessionRepository = userTestSessionRepository;
            this.usersRepository = usersRepository;
            this.emailGateway = emailGateway;
        }

        #region User

        [HttpGet("all/{questionnaireId}")]
        public async Task<List<User>> GetAllUsers(int questionnaireId)
        {
            List<ApplicationUser> users = await usersRepository.GetAllUsersAsync();
            List<User> result = [];

            foreach (var user in users)
            {
                // change questionnaire id?
                List<SavedUserAnswers> answers = await questionnaireRepository.GetAllUserAnswersAsync(user.Id, questionnaireId);
                answers = answers.OrderByDescending(d => d.CompletedAt).ToList();

                if (answers != null)
                {
                    result.Add(new User(
                        user.Id,
                        user.FullName,
                        user.Email,
                        answers,
                        Role.User
                    ));
                }
            }

            return result;
        }

        [HttpGet("{userId}/{questionnaireId}")]
        public async Task<Results<NotFound, Ok<User>>> GetUserById(string userId, int questionnaireId)
        {
            ApplicationUser? appUser = await usersRepository.GetUserByIdAsync(userId);

            if (appUser == null)
                return TypedResults.NotFound();

            List<SavedUserAnswers> answers = await questionnaireRepository.GetAllUserAnswersAsync(appUser.Id, questionnaireId);
            answers = answers.OrderByDescending(d => d.CompletedAt).ToList();
            User user = new(
                appUser.Id,
                appUser.FullName,
                appUser.Email,
                answers,
                Role.User
            );

            return TypedResults.Ok(user);
        }

        #endregion

        #region Questionnaire

        [HttpPost("{userId}/questionnaire/{questionnaireId}/start")]
        public async Task<string> StartQuestionnaire(string userId, int questionnaireId)
        {
            var session = await userTestSessionRepository.StartUserTestSessionAsync(userId, questionnaireId);
            return session.Id.ToString();
        }

        [HttpPost("{userId}/questionnaire/{testSessionId}/storeAnswer/{questionId}")]
        public async Task StoreUserAnswer(string userId, Guid testSessionId, int questionId, [FromBody] StoreAnswerRequest request)
        {
            await userTestSessionRepository.StoreUserAnswer(testSessionId, questionId, request.Answer);
        }

        [HttpGet("{userId}/questionnaire/{testSessionId}/nextQuestion")]
        public async Task<NextQuestion?> GetNextQuestion(string userId, string testSessionId)
        {
            var id = Guid.Parse(testSessionId);
            var session = await userTestSessionRepository.GetTestSessionAsync(id);
            var answers = await userTestSessionRepository.GetUserAnswers(id);
            Questionnaire questionnaire = await questionnaireRepository.GetQuestionnaireAsync(session.QuestionnaireId);

            if (questionnaire.Questions.Count == answers.Count)
            {
                return null;
            }

            // randomize questions order
            Random r = new Random();
            int next = r.Next(questionnaire.Questions.Count);
            var answeredQuestions = answers.Select(a => a.QuestionId).ToHashSet();
            while (answeredQuestions.Contains(questionnaire.Questions[next].Id))
            {
                next = (next + 1) % questionnaire.Questions.Count;
            }

            var q = questionnaire.Questions[next];
            return new NextQuestion
            {
                Id = q.Id,
                Text = q.Text,
                AllQuestionsCount = questionnaire.Questions.Count,
                AnsweredQuestionsCount = answers.Count
            };
        }

        [HttpPost("{userId}/questionnaire/{questionnaireId}/{testSessionId}/complete")]
        public async Task CompleteQuestionnaire(string userId, int questionnaireId, string testSessionId)
        {
            var id = Guid.Parse(testSessionId);
            await userTestSessionRepository.CompleteUserTestSessionAsync(id);

            //await SendEmail(userId, questionnaireId, testSessionId);
        }

        [HttpGet("{userId}/questionnaire/{questionnaireId}/results/last")]
        public async Task<Results<NotFound, Ok<SavedUserAnswers>>> GetLastUserAnswers(string userId, int questionnaireId)
        {
            var lastAnswer = await questionnaireRepository.GetLastUserAnswersAsync(userId, questionnaireId);

            if (lastAnswer == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(lastAnswer);
        }

        [HttpGet("{userId}/questionnaire/{questionnaireId}/results/{sessionId}")]
        public async Task<Results<NotFound, Ok<SavedUserAnswers>>> GetOneUserAnswers(string userId, int questionnaireId, string sessionId)
        {
            var answer = await questionnaireRepository.GetUserAnswersBySessionIdAsync(userId, questionnaireId, sessionId);

            if (answer == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(answer);
        }

        [HttpGet("{userId}/questionnaire/{questionnaireId}/results")]
        public async Task<Results<NotFound, Ok<List<SavedUserAnswers>>>> GetAllUserAnswers(string userId, int questionnaireId)
        {
            var allAnswers = await questionnaireRepository.GetAllUserAnswersAsync(userId, questionnaireId);

            if (allAnswers == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(allAnswers);
        }

        [HttpPost("sendemail")]
        public async Task TestSendEmail()
        {
            string toEmail = "minko.anton@gmail.com";
            string toName = "Anton Minko";
            string subject = $"Результаты теста ОКЭАН для {toName}";
            string url = $"{ResultsBaseUrl}/1";

            var builder = new EmailMassageBuilder();
            string message = await builder.BuildTestResultsMessage(toName, new Dictionary<string, double>
            {
                { "O", 0.5 },
                { "К", 1.52 },
                { "Э", 2.0 },
                { "А", 3.5 },
                { "Н", 4.5 },
            }, url);

            await emailGateway.SendEmailAsync(toEmail, toName, subject, message);
        }

        private async Task SendEmail(string userId, int questionnaireId, string sessionId)
        {
            var answer = await questionnaireRepository.GetUserAnswersBySessionIdAsync(userId, questionnaireId, sessionId);
            var user = await usersRepository.GetUserByIdAsync(userId);

            if (answer == null || user == null)
            {
                return;
            }

            string toEmail = user.Email;
            string toName = user.FullName;
            string subject = $"Результаты теста ОКЭАН для {toName}";
            string url = $"{ResultsBaseUrl}/{questionnaireId}/{userId}/{sessionId}";
            
            var builder = new EmailMassageBuilder();
            string message = await builder.BuildTestResultsMessage(toName, answer.Result, url);

            await emailGateway.SendEmailAsync(toEmail, toName, subject, message);
        }

        #endregion
    }
}