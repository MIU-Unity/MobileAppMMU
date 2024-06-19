using System;
using Plugins.DebugAttribute;
using Common.Utility;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class AttemptsBehaviour : Singleton<AttemptsBehaviour>
    {
        public static Action<int> OnAttemptsChanged;

        private const int MaxAttempts = 3;
        private int _currentAttempts;

        public void Initialize()
        {
            _currentAttempts = MaxAttempts;
            Debug.Log("Attempts Behaviour Initialized");
        }

        [Debug]
        public void Decrease()
        {
            if (_currentAttempts == 0)
                GameplayEventHandler.Instance.OnGameCompleted();
            
            _currentAttempts--;
            OnAttemptsChanged?.Invoke(_currentAttempts);
        }
    }
}