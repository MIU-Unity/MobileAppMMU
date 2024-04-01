using System;
using System.Collections;
using Common.Utility;
using Plugins.DebugAttribute;
using UnityEngine;


namespace Gameplay
{
    public class TimerBehaviour : Singleton<TimerBehaviour>
    {
        private float _currentTimeCount;
        private bool _timerEnabled;

        public static Action TimeIsUp;
        
        [Debug(1)]
        public void Initialize(int k)
        {
            _currentTimeCount = Mathf.Clamp(120-30*k,30,90);
            _timerEnabled = true;
        }
        
        private void Update()
        {
            if (_timerEnabled == false) return;
            
            if (_currentTimeCount >= 0)
            {
                _currentTimeCount -= Time.deltaTime;
            }
            else
            {
                _timerEnabled = false;
                TimeIsUp?.Invoke();
            }
        }
        
        public string GetTimeString()
        {
            float minutes = Mathf.FloorToInt(_currentTimeCount / 60);
            float seconds = Mathf.FloorToInt(_currentTimeCount % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }
}