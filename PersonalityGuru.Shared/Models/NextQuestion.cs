namespace PersonalityGuru.Shared.Models
{
    public class NextQuestion
    {
        public int Id { get; set;}
        
        public string Text { get; set; }
        
        public int AllQuestionsCount { get; set; }

        public int AnsweredQuestionsCount { get; set; }
    }
}