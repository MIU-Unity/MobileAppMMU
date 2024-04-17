using System;
using System.Collections;
using Common.Utility;
using Plugins.DebugAttribute;
using UnityEngine;


namespace Gameplay
{
    public class TimerBehaviour : Singleton<TimerBehaviour>
    {
        public float MaxTimeCount { get; private set; }
        public float CurrentTimeCount { get; private set; }
        private bool _timerEnabled;

        public static Action TimeIsUp;

        [Debug(1)]
        public void Initialize(int k)
        {
            CurrentTimeCount = MaxTimeCount = Mathf.Clamp(120 - 30 * k, 30, 90);
            _timerEnabled = true;
        }

        private void Update()
        {
            if (_timerEnabled == false) return;

            if (CurrentTimeCount > 0)
            {
                CurrentTimeCount -= Time.deltaTime;
            }
            else
            {
                CurrentTimeCount = 0;
                _timerEnabled = false;
                TimeIsUp?.Invoke();
            }
        }

        public string GetTimeAsString()
        {
            float minutes = Mathf.FloorToInt(CurrentTimeCount / 60);
            float seconds = Mathf.FloorToInt(CurrentTimeCount % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
}