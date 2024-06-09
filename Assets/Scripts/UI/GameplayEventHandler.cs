using System;
using Common.Utility;
using System.Collections;
using Crystal;
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
        [SerializeField] private SafeArea _safePanel;
        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private GameObject _completeGamePopup;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private Slider _timerSlider;

        private bool _timerGUIEnabled;
        
        public void Initialize()
        {
            AttemptsBehaviour.OnAttemptsChanged += OnAttemptsChanged;

            _timerSlider.maxValue = TimerBehaviour.Instance.GetFloat;
            _timerSlider.value = 0;

            StartCoroutine(UpdateTimerUI());
            
            Debug.Log("Gameplay Event Handler Initialized");
        }


        private void OnAttemptsChanged(int value)
        {
            Debug.Log($"Attempt changed. Current value: {value}");
        }

        private IEnumerator UpdateTimerUI()
        {
            _timerGUIEnabled = true;
            while (true)
            {
                if (!_timerGUIEnabled) continue;
                
                _timerText.text = TimerBehaviour.Instance.GetString;
                _timerSlider.value = TimerBehaviour.Instance.GetFloat;
                yield return new WaitForSeconds(1f);
            }
        }

        public void OnPause(bool value) => _timerGUIEnabled = !value;

        public void OnHintButtonClick()
        {
            //TODO: автоматическое определение уровня и типа подсказки
            PopupConstructor.Instance.Open(
                "Подсказка",
                HintBehaviour.Instance.Get(1,"light"),
                PopupType.Clear);
        }

        [Debug]
        //TODO: Вызов функции событием
        public void OnGameCompleted()
        {
            GameObject gameCompletedPopup = Instantiate(_completeGamePopup.gameObject, _safePanel.transform);
        }
        
    }
}