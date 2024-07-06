using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityGuru.Shared.Models
{
    public class UserAnswers
    {
        public int Id { get; set; }
        public string UserId { get; init; }
        public int QuestionnaireId { get; init; }
        public Dictionary<int, AnswerOption> Answers { get; init; }

        public UserAnswers(string userId, int questionnaireId, Dictionary<int, AnswerOption>? answers = null)
        {
            UserId = userId;
            QuestionnaireId = questionnaireId;
            Answers = answers ?? new Dictionary<int, AnswerOption>();
        }
    }
}