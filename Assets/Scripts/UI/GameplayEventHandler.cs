using System;
using Common.Utility;
using System.Collections;
using Crystal;
using Gameplay;
using Plugins.DebugAttribute;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{

    public class GameplayEventHandler : Singleton<GameplayEventHandler>
    {
        [SerializeField] private SafeArea _safePanel;
        [SerializeField] private PausePopup _pausePopup;
        [SerializeField] private GameObject _completeGamePopup;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private Slider _timerSlider;

        [Space(10)]
        [Header("Question")]
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private Button[] _buttons;
        
        private bool _timerGUIEnabled;
        private int _count = 0;
        
        public void Initialize()
        {
            AttemptsBehaviour.OnAttemptsChanged += OnAttemptsChanged;

            _timerSlider.maxValue = TimerBehaviour.Instance.GetFloat;
            _timerSlider.value = 0;
            PauseBehaviour.OnPause += OnPause;

            StartCoroutine(UpdateTimerUI());
            
            Debug.Log("Gameplay Event Handler Initialized");
        }
        
        private void OnDestroy()
        {
            PauseBehaviour.OnPause -= OnPause;
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
                HintBehaviour.Instance.Get(1, (HintType)_count),
                PopupType.Clear);
            if (_count == 0) ++_count;
        }

        [Debug]
        //TODO: Вызов функции событием
        public void OnGameCompleted()
        {
            GameObject gameCompletedPopup = Instantiate(_completeGamePopup, _safePanel.transform);
            var scoreText = gameCompletedPopup.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            var replaced = scoreText.text.Replace("{score}", ScoreBehaviour.Instance.Get().ToString());
            scoreText.text = replaced;
        }

        public void BackToMenuButton()
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        public void DisplayQuestion(string question, string answer, string[] variants)
        {
            _questionText.text = question;

            foreach (var button in _buttons)
                button.onClick.RemoveAllListeners();
            
            int answerButton = Random.Range(0, _buttons.Length);
            _buttons[answerButton].GetComponentInChildren<TextMeshProUGUI>().text = answer;
            _buttons[answerButton].onClick.AddListener(() => QuestionsQueue.Instance.NextQuestion());
            _buttons[answerButton].onClick.AddListener(() => ScoreBehaviour.Instance.Increase());
            
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (i != answerButton)
                {
                    _buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = variants[i];
                    _buttons[i].onClick.AddListener(() => AttemptsBehaviour.Instance.Decrease());
                }
            }
        }
        
        
    }
}