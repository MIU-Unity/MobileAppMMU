using System;
using System.Collections;
using Common.Utility;
using Interfaces;
using Plugins.DebugAttribute;
using UnityEngine;


namespace Gameplay
{
    public class TimerBehaviour : Singleton<TimerBehaviour>, ICanBePaused
    {
        public static Action TimeIsUp;

        /// <summary>
        /// Значение таймера
        /// </summary>
        public float GetFloat => _currentTimeCount;

        /// <summary>
        /// Значения таймера в строке вида 00:00
        /// </summary>
        public string GetString
        {
            get
            {
                float minutes = Mathf.FloorToInt(_currentTimeCount / 60);
                float seconds = Mathf.FloorToInt(_currentTimeCount % 60);

                return string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

        private float _currentTimeCount;
        private bool _timerEnabled;

        public void Initialize(int k)
        {
            _currentTimeCount = Mathf.Clamp(120 - 30 * k, 30, 90);
        }

        [Debug]
        public void Enable() => _timerEnabled = true;

        private void Update()
        {
            if (_timerEnabled == false) return;

            if (_currentTimeCount > 0)
            {
                _currentTimeCount -= Time.deltaTime;
            }
            else
            {
                _currentTimeCount = 0;
                _timerEnabled = false;
                TimeIsUp?.Invoke();
            }
        }

        public void OnPause(bool value) => _timerEnabled = !value;
        

    }
}