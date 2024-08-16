using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityGuru.Shared.Models
{
    public class UserTestSession
    {
        public Guid Id { get; set; }
        public string UserId { get; init; }
        public int QuestionnaireId { get; init; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }

        public TestSessionState State { get; set; } = TestSessionState.InProgress;
        
        public UserTestSession(string userId, int questionnaireId)
        {
            UserId = userId;
            QuestionnaireId = questionnaireId;
        }
    }
}