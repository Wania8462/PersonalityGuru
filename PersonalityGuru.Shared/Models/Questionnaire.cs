namespace PersonalityGuru.Shared.Models
{
    public class Questionnaire
    {
        public int Id { get; set;  }

        public string Name { get; set; }

        public List<Question> Questions { get; set; }
    }
}