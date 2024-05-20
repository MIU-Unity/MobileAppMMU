using System;
using Common.Utility;
using System.Collections;
using Gameplay;
using Interfaces;
using Plugins.DebugAttribute;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class GameplayEventHandler : Singleton<GameplayEventHandler>, ICanBePaused
    {

        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private Slider _timerSlider;

        private bool _enabled;
        
        [Debug]
        public void Initialize()
        {
            AttemptsBehaviour.OnAttemptsChanged += OnAttemptsChanged;

            _timerSlider.maxValue = TimerBehaviour.Instance.GetFloat;
            _timerSlider.value = 0;

            StartCoroutine(UpdateTimerUI());
        }


        private void OnAttemptsChanged(int value)
        {
            Debug.Log($"Attempt changed. Current value: {value}");
        }

        private IEnumerator UpdateTimerUI()
        {
            _enabled = true;
            while (true)
            {
                if (!_enabled) continue;
                
                _timerText.text = TimerBehaviour.Instance.GetString;
                _timerSlider.value = TimerBehaviour.Instance.GetFloat;
                yield return new WaitForSeconds(1f);
            }
        }

        public void OnPause(bool value) => _enabled = !value;
        
    }
}