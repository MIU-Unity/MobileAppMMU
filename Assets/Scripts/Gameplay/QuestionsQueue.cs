using Common.Utility;
using UI;

namespace Gameplay
{
    public class QuestionsQueue : Singleton<QuestionsQueue>
    {
        private Question[] _questions;
        private int _currentQuestion = 0;
        
        public void Initialize()
        {
            _questions = GetQuestions(Data.Level.GetCurrent());
            _currentQuestion = 0;
            DisplayQuestion();
        }

        private Question[] GetQuestions(int levelID)
        {
            //TODO: запрос списка вопросов по id уровня
            
            //заглушка
            Question[] result = new Question[]
            {
                new Question(0,"Вопрос 1",3, new string[] {"1","2","3","4"}),
                new Question(0,"Вопрос 2",1, new string[] {"1","4","3","2"}),
                new Question(0,"Вопрос 3",0, new string[] {"4","2","3","1"})
            };
                
            return result;
        }

        public void NextQuestion()
        {
            _currentQuestion++;
            if (_currentQuestion >= _questions.Length)
            {
                GameplayEventHandler.Instance.OnGameCompleted();
                return;
            }
            DisplayQuestion();
        }
        
        private void DisplayQuestion()
        {
            GameplayEventHandler.Instance.DisplayQuestion(
            _questions[_currentQuestion].Text,
            _questions[_currentQuestion].RightAnswerID,
            _questions[_currentQuestion].Answers
            );
        }
        
    }

    public class Question
    {
        public int ID { get; private set; }
        public string Text { get; private set; }
        public int RightAnswerID { get; private set; }
        public string[] Answers { get; private set; }

        public Question(int id, string text, int rightAnswerID, string[] answers)
        {
            this.ID = id;
            this.Text = text;
            this.RightAnswerID = rightAnswerID;
            this.Answers = answers;
        }
    }
}