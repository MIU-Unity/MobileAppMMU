using System;
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
            
            // AnswerBehaviour.Instance.Initialize(); // help is needed
            //add more instances when they release
            
            GameplayEventHandler.Instance.Initialize(); // всегда последним
        }
    }
}