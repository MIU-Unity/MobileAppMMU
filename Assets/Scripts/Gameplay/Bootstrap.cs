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
            AttemptsBehaviour.Instance.Initialize();
            TimerBehaviour.Instance.Initialize(Difficult.Get());
            ScoreBehaviour.Instance.Initialize();
            GameplayEventHandler.Instance.Initialize();
            QuestionsQueue.Instance.Initialize();
        }
    }
}