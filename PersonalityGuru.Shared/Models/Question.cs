namespace PersonalityGuru.Shared.Models
{
    public class Question
    {
        public int Id { get; set;}
        public string Text { get; set; }
        public string Group { get; set; }
        public bool InvertedScore { get; set; } = false;

        public int TestId { get; set; }
        public Questionnaire Test { get; set; }
    }
}