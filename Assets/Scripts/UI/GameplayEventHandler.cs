using System;
using Common.Utility;
using System.Collections;
using Crystal;
using Data;
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
            PopupConstructor.Instance.Open(
                "Подсказка",
                HintBehaviour.Instance.Get(Level.GetCurrent(), (HintType)_count),
                PopupType.Clear);
            if (_count == 0) ++_count;
        }
        
        public void OnGameCompleted()
        {
            PopupGameCompleted gameCompletedPopup = 
                Instantiate(_completeGamePopup, _safePanel.transform)
                .GetComponent<PopupGameCompleted>();
            var replaced = gameCompletedPopup.ScoreText.text
                .Replace("{score}", ScoreBehaviour.Instance.Get().ToString());
            gameCompletedPopup.ScoreText.text = replaced;

            int currentLevel = Level.GetCurrent();
            currentLevel++;
            if (currentLevel > Level.GetMax())
                currentLevel = Level.GetMax();
            
            Level.SetCurrent(currentLevel);
            SaveLoadManager.Instance.Save();
        }

        public void BackToMenuButton()
        {
            PopupConstructor.Instance.Open(
                "Выход",
                "Вы действительно хотите выйти из игры?",
                PopupType.WithButtons,
                () => SceneManager.LoadScene("MainMenuScene"));
        }

        public void DisplayQuestion(string question, int answerID, string[] variants)
        {
            _questionText.text = question;

            foreach (var button in _buttons)
            {
                button.interactable = true;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(()=> button.interactable = false);
            }
            
            _buttons[answerID].onClick.RemoveAllListeners();
            _buttons[answerID].GetComponentInChildren<TextMeshProUGUI>().text = variants[answerID];
            _buttons[answerID].onClick.AddListener(() => ScoreBehaviour.Instance.Increase());
            _buttons[answerID].onClick.AddListener(() => QuestionsQueue.Instance.NextQuestion());
            
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (i != answerID)
                {
                    _buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = variants[i];
                    _buttons[i].onClick.AddListener(() => AttemptsBehaviour.Instance.Decrease());
                }
            }
            
        }
        
        
    }
}