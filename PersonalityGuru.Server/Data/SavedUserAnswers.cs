using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PersonalityGuru.Shared.Models;

namespace PersonalityGuru.Server.Data
{
    public class SavedUserAnswers
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; init; }
        public int QuestionnaireId { get; init; }
        public DateTime CompletedAt { get; set; }
        public Dictionary<int, AnswerOption> Answers { get; init; }

        public SavedUserAnswers(string userId, int questionnaireId, Dictionary<int, AnswerOption> answers)
        {
            Id = 0; // EF will set this
            UserId = userId;
            QuestionnaireId = questionnaireId;
            Answers = answers;
            CompletedAt = DateTime.Now;
        }
    }
}