using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Gameplay
{
    public class TimerBehaviour : MonoBehaviour, IDisplayable
    {
        private float _currentTimeCount;
        private bool _timerEnabled;
        
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _currentTimeCount = GetMaxTimeAmount();
            _timerEnabled = true;
            StartCoroutine(UpdateTimer());
        }
        
        //TODO: link with difficulty
        private float GetMaxTimeAmount()
        {
            int k = 2; //temp property
            return 120 - 30 * k;
        }

        private void Update()
        {
            if (_timerEnabled == false) return;

            if (_currentTimeCount >= 0)
            {
                _currentTimeCount -= Time.deltaTime;
                //Display();
            }
            else
            {
                TimeIsUp();
            }
        }

        private IEnumerator UpdateTimer()
        {
            while (_timerEnabled)
            {
                Display();
                yield return new WaitForSeconds(1);
            }
        }

        //TODO: display timer in UI
        public void Display()
        {
            float minutes = Mathf.FloorToInt(_currentTimeCount / 60);
            float seconds = Mathf.FloorToInt(_currentTimeCount % 60);

            string timer = string.Format("{0:00}:{1:00}", minutes, seconds);
            
            UnityEngine.Debug.Log(timer,this);
        }

        //TODO: reduce attempts
        private void TimeIsUp()
        {
            _timerEnabled = false;
        }
    }
}