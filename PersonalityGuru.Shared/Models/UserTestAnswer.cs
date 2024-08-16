using System.ComponentModel.DataAnnotations;

namespace PersonalityGuru.Shared.Models
{
    public class UserTestAnswer
    {
        [Key]
        public int Id { get; set; }
        public Guid UserTestSessionId { get; set; }
        public UserTestSession UserTestSession { get; set; }
        public int QuestionId { get; set; }
        public AnswerOption AnswerOption { get; set; }
    }
}