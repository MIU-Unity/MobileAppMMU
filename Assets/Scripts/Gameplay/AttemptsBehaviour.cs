using System;
using Plugins.DebugAttribute;
using UnityEngine;

namespace Gameplay
{
    public class AttemptsBehaviour : MonoBehaviour
    {
        public static AttemptsBehaviour Instance { get; private set; }
        public static Action<int> OnAttemptsChanged;
        
        private readonly int _maxAttempts = 3;
        private int _currentAttempts = 3;

        private void Awake()
        {
            if (Instance != null && Instance.GetInstanceID() != this.GetInstanceID())
            {
                throw new Exception(string.Format("Instance of {0} is already exist",this.name));
            }

            Instance = this;
        }

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