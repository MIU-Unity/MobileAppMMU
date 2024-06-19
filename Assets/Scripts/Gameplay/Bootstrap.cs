using System;
using Data;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public void Start()
        {
            //HintBehaviour.Instance.Initialize();
            AttemptsBehaviour.Instance.Initialize();
            TimerBehaviour.Instance.Initialize(Difficult.Get());
            ScoreBehaviour.Instance.Initialize();
            QuestionsQueue.Instance.Initialize();
            
            // AnswerBehaviour.Instance.Initialize(); // help is needed
            //add more instances when they release
            
            GameplayEventHandler.Instance.Initialize(); // всегда последним
        }
    }
}