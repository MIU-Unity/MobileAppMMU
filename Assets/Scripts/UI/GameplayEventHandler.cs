using System.Collections;
using Gameplay;
using Plugins.DebugAttribute;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameplayEventHandler : MonoBehaviour
    {
        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private Slider _timerSlider;

        [Debug]
        public void Initialize()
        {
            PauseBehaviour.OnPause += OnPause;
            AttemptsBehaviour.OnAttemptsChanged += OnAttemptsChanged;

            _timerSlider.maxValue = TimerBehaviour.Instance.MaxTimeCount;
            _timerSlider.value = 0;

            StartCoroutine(UpdateTimerUI());
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

        private IEnumerator UpdateTimerUI()
        {
            while (true)
            {
                if (PauseBehaviour.Instance.IsPaused == false)
                {
                    _timerText.text = TimerBehaviour.Instance.GetTimeAsString();
                    _timerSlider.value = TimerBehaviour.Instance.CurrentTimeCount;
                }
                yield return new WaitForSeconds(1f);
            }
        }
        
    }
}