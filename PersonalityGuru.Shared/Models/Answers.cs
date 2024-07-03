using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityGuru.Shared.Models
{
    public class Answers
    {
        public string UserId { get; set; }
        public long QuestionnaireId { get; set; }
        public long QuestionId { get; set; }
        public AnswerOption Answer { get; set; }

        public Answers(string userId, long questionnaireId, long questionId, AnswerOption answer)
        {
            UserId = userId;
            QuestionnaireId = questionnaireId;
            QuestionId = questionId;
            Answer = answer;
        }
    }
}