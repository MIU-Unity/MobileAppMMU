using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Utility;
using Data;
using Newtonsoft.Json;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class QuestionsQueue : Singleton<QuestionsQueue>
    {
        private List<QuestionEntity> _questions;
        public int CurrentQuestion { get; private set; } = 0;
        
        public async Task Initialize()
        {
            _questions = await GetQuestions(Data.Level.GetCurrent());
            CurrentQuestion = 0;
            DisplayQuestion();
            
            Debug.Log("Current Level: " + Data.Level.GetCurrent());
        }

        private async Task<List<QuestionEntity>> GetQuestions(int levelID)
        {
            var x = await CustomHttpClient.Instance.Get($"/questions?populate=*&filters[levels][id][$eq]={Level.GetCurrent()}");
            var y = JsonConvert.DeserializeObject<ServerResponse<QuestionEntity>>(x);
            
            var result = y.data;
                
            return result;
        }

        public void NextQuestion()
        {
            CurrentQuestion++;
            if (CurrentQuestion >= _questions.Count)
            {
                GameplayEventHandler.Instance.OnGameCompleted(true);
                return;
            }
            DisplayQuestion();
        }
        
        private void DisplayQuestion()
        {
            GameplayEventHandler.Instance.DisplayQuestion(
            _questions[CurrentQuestion].question,
            _questions[CurrentQuestion].right_answer,
            _questions[CurrentQuestion].answers
            );
        }

        public string GetHint()
        {
            return _questions[CurrentQuestion].historical_reference;
        }
        
    }
    
}