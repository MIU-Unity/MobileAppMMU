using System;
using Common.Utility;
using Gameplay;
using Plugins.DebugAttribute;
using UnityEngine;

namespace UI
{
    public class GameplayEventHandler : Singleton<GameplayEventHandler>
    {
        
        [SerializeField] private PausePopup _pausePopup;

        public void Initialize()
        {
            PauseBehaviour.OnPause += OnPause;
            AttemptsBehaviour.OnAttemptsChanged += OnAttemptsChanged;
            Debug.Log("GameplayEventHandler initialized");
        }

        public void OnDestroy()
        {
            PauseBehaviour.OnPause -= OnPause;
            AttemptsBehaviour.OnAttemptsChanged -= OnAttemptsChanged;
            Debug.Log("GameplayEventHandler destroyed");
        }
        
        
        private void OnAttemptsChanged(int value)
        {
            Debug.Log($"Attempt changed. Current value: {value}");
        }

        private void OnPause(bool value)
        {
            Debug.Log("OnPause: " + value);
            if (value)
            {
                _pausePopup.Open();
            }
            else
            {
                _pausePopup.Close();
            }
            
        }
    }
}