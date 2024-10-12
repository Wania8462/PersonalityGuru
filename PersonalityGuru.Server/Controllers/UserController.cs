using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalityGuru.Server.Data;
using PersonalityGuru.Server.Repositories;
using PersonalityGuru.Shared.Models;
using System.Threading.Tasks;

namespace PersonalityGuru.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IQuestionnaireRepository questionnaireRepository;
        private readonly IUserTestSessionRepository userTestSessionRepository;
        private readonly IUsersRepository usersRepository;

        public UserController(
            IQuestionnaireRepository questionnaireRepository,
            IUserTestSessionRepository userTestSessionRepository,
            IUsersRepository usersRepository
        )
        {
            this.questionnaireRepository = questionnaireRepository;
            this.userTestSessionRepository = userTestSessionRepository;
            this.usersRepository = usersRepository;
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
                        answers
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
                answers
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

        [HttpPost("{userId}/questionnaire/{testSessionId}/complete")]
        public async Task CompleteQuestionnaire(string userId, string testSessionId)
        {
            var id = Guid.Parse(testSessionId);
            await userTestSessionRepository.CompleteUserTestSessionAsync(id);
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

        #endregion
    }
}