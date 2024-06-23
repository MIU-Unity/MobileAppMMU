using Data;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{

    public class GameplayEventHandler : Common.Utility.Singleton<GameplayEventHandler>
    {
        [SerializeField] private GameObject _safePanel;
        [SerializeField] private GameObject _pausePopup;
        [SerializeField] private GameObject _completeGamePopup;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private Slider _timerSlider;

        [Space(10)]
        [Header("Question")]
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private Button[] _buttons;
        
        private bool _timerGUIEnabled;
        private bool _timeIsUp;
        private int _count = 0;
        
        public void Initialize()
        {
            AttemptsBehaviour.OnAttemptsChanged += OnAttemptsChanged;
            PauseBehaviour.OnPause += OnPause;
            TimerBehaviour.TimeIsUp += TimeIsUp;
            
            var buttonsGameObject = GameObject.Find("Answers").transform;
            for (int i = 0; i < buttonsGameObject.childCount; i++) 
                _buttons[i] = buttonsGameObject.GetChild(i).GetComponent<Button>();

            _questionText = GameObject.Find("QuestionText").GetComponent<TextMeshProUGUI>();
            _timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
            _timerSlider = GameObject.Find("TimerSlider").GetComponent<Slider>();
            _timerSlider.maxValue = TimerBehaviour.Instance.GetFloat;
            _timerSlider.value = 0;

            _safePanel = GameObject.Find("SafePanel");
            
            _timerGUIEnabled = true;
            _timeIsUp = false;            
            TimerBehaviour.Instance.Enable();
            
            Debug.Log("Gameplay Event Handler Initialized");
        }

        private void TimeIsUp()
        {
            _timeIsUp = true;
        } 


        private void OnDestroy()
        {
            PauseBehaviour.OnPause -= OnPause;
            TimerBehaviour.TimeIsUp -= TimeIsUp;
        }

        private void OnDisable()
        {
            PauseBehaviour.OnPause -= OnPause;
            TimerBehaviour.TimeIsUp -= TimeIsUp;
        }
        
        private void OnAttemptsChanged(int value)
        {
            Debug.Log($"Attempt changed. Current value: {value}");
        }

        private void FixedUpdate()
        {
            if (_timeIsUp) return;
            if (_timerGUIEnabled == false) return;
            
            _timerText.text = TimerBehaviour.Instance.GetString;
            _timerSlider.value = TimerBehaviour.Instance.GetFloat;
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
        
        public void OnGameCompleted(bool success)
        {
            PopupGameCompleted gameCompletedPopup = 
                Instantiate(_completeGamePopup, _safePanel.transform)
                .GetComponent<PopupGameCompleted>();
            var replaced = gameCompletedPopup.ScoreText.text
                .Replace("{score}", ScoreBehaviour.Instance.Get().ToString());
            gameCompletedPopup.ScoreText.text = replaced;
            replaced = gameCompletedPopup.TimeText.text
                .Replace("{time}", TimerBehaviour.Instance.GetPlayedTimeString);
            gameCompletedPopup.TimeText.text = replaced;
            gameCompletedPopup.SetNextButtonText(success);

            if (success)
            {
                int currentLevel = Level.GetCurrent();
                currentLevel++;
                if (currentLevel > Level.GetMax())
                    currentLevel = Level.GetMax();

                Level.SetCurrent(currentLevel);
                SaveLoadManager.Instance.Save();
            }
        }

        public void BackToMenuButton()
        {
            PopupConstructor.Instance.Open(
                "Выход",
                "Вы действительно хотите выйти из игры?",
                PopupType.WithButtons,
                () => SceneManager.LoadScene("MainMenuScene"));
        }

        public void NextLevelButton()
        {
            SaveLoadManager.Instance.Save();
            SceneManager.LoadScene("LevelBootstrap");
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