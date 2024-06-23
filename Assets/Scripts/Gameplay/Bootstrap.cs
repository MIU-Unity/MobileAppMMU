using System;
using System.Collections;
using Data;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Start()
        {
            yield return new WaitForFixedUpdate();
            AttemptsBehaviour.Instance.Initialize();
            TimerBehaviour.Instance.Initialize(Difficult.Get());
            ScoreBehaviour.Instance.Initialize();
            GameplayEventHandler.Instance.Initialize();
            QuestionsQueue.Instance.Initialize();
        }
    }
}