using System;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public void Start()
        {
            GameplayEventHandler.Instance.Initialize();
            TimerBehaviour.Instance.Initialize(1);
            HintBehaviour.Instance.Initialize();
            // AnswerBehaviour.Instance.Initialize(); // help is needed
            //add more instances when they release, like HintBehaviour, AttemptsBehaviour, etc.
        }
    }
}