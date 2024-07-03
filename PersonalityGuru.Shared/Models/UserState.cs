namespace PersonalityGuru.Shared.Models
{
    public class UserState
    {
        public UserState()
        {
            
        }

        public UserState(string userName)
        {
            UserName = userName;
        }
        
        public string UserName { get; set; }
        public Questionnaire CurrentTest { get; set; }
        public List<Answers> CurrentAnswers { get; set; }

        private int nextQuestion = 0;
 
        public void StartTest(Questionnaire questionnaire) {
            //TODO: Randimaze questions
            CurrentTest = questionnaire;
            CurrentAnswers = [];
            nextQuestion = 0;
        }

        public Question? GetNextQuestion() {
            if (nextQuestion == CurrentTest.Questions.Count) 
                return null;
            
            var nextQ = CurrentTest.Questions[nextQuestion];
            nextQuestion++;
            return nextQ;
        }

        public Question? SeeNextQuestion()
        {
            return nextQuestion == CurrentTest.Questions.Count ? null : CurrentTest.Questions[nextQuestion];
        }

        public void SaveAnswer(Question question, AnswerOption userAnswer) {
            Answers answer = new(
                UserName,
                CurrentTest.Id,
                question.Id,
                userAnswer);
            CurrentAnswers.Add(answer);
        }
    }
}