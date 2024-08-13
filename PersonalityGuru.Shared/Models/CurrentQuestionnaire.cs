namespace PersonalityGuru.Shared.Models
{
    public class CurrentQuestionnaire
    {
        public CurrentQuestionnaire()
        {
            
        }

        public CurrentQuestionnaire(string userName)
        {
            UserName = userName;
        }
        
        public string UserName { get; set; }
        public Questionnaire CurrentTest { get; set; }
        //public UserAnswers CurrentAnswers { get; set; }

        private int nextQuestion = 0;
 
        public void StartTest(Questionnaire questionnaire) {
            //TODO: Randomize questions
            CurrentTest = questionnaire;
            //CurrentAnswers = new(UserName, questionnaire.Id);
            nextQuestion = 0;
        }

        public Question? GetNextQuestion() {
            Console.WriteLine("Test");
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
            // if (CurrentAnswers.Answers.ContainsKey(question.Id))
            // {
            //     CurrentAnswers.Answers[question.Id] = userAnswer;
            // }
            // else {
            //     CurrentAnswers.Answers.Add(question.Id, userAnswer);
            // }
        }
    }
}