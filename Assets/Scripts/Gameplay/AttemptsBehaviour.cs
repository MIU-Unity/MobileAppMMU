using System;
using Plugins.DebugAttribute;
using Common.Utility;
using UnityEngine;

namespace Gameplay
{
    public class AttemptsBehaviour : Singleton<AttemptsBehaviour>
    {
        public static Action<int> OnAttemptsChanged;
        
        private readonly int _maxAttempts = 3;
        private int _currentAttempts = 3;

        public void Initialize()
        {
            _currentAttempts = _maxAttempts;
        }

        [Debug]
        public void Decrease()
        {
            if(_currentAttempts == 0) 
                throw new Exception("Cannot decrease attempts below 0");
            _currentAttempts--;
            OnAttemptsChanged?.Invoke(_currentAttempts);
        }
    }
}