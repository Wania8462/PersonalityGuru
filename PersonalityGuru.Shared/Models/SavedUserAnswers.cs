using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityGuru.Shared.Models
{
    public class SavedUserAnswers
    {
        public string UserId { get; init; }
        public int QuestionnaireId { get; init; }
        public DateTime CompletedAt { get; set; }
        public Dictionary<string, float> Result { get; init; }

        public SavedUserAnswers(string userId, int questionnaireId, Dictionary<string, float> result)
        {
            UserId = userId;
            QuestionnaireId = questionnaireId;
            CompletedAt = DateTime.Now;
            Result = result;
        }
    }
}
