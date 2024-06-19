using Common.Utility;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PausePopup : Singleton<PausePopup>
    {
        [SerializeField] private GameObject _pauseMenuObject;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _backToMenuButton;
        
        private bool _isFirstOpen = true;
        
        public void Open()
        {
            _pauseMenuObject.SetActive(true);
            if(_isFirstOpen) Initialize();
        }

        public void Close()
        {
            _pauseMenuObject.SetActive(false);
        }
        
        private void Initialize()
        {
            Debug.Log("Initialize PausePopup");
            _resumeButton.onClick.RemoveAllListeners();
            _resumeButton.onClick.AddListener(() => PauseBehaviour.Instance.Set(false));
            _backToMenuButton.onClick.RemoveAllListeners();
            _backToMenuButton.onClick.AddListener(() =>
                PopupConstructor.Instance.Open(
                    "Выйти в меню",
                    "Вы уверены, что хотите выйти в меню? Весь несохраненный прогресс будет удален.",
                    PopupType.WithButtons,
                    () => SceneManager.LoadScene("MainMenuScene"))
                );
            
            //PauseBehaviour.OnPause += OnPause;
            
            //TODO: Add settings button
            // _settingsButton.onClick.AddListener(() => OnSettingsButtonClicked()?.Invoke();
            _isFirstOpen = false;
        }

        private void OnDestroy()
        {
            //PauseBehaviour.OnPause -= OnPause;
            
        }
        
        public void OnPause(bool value)
        {
            if (value) Open();
            else Close();
        }
    }
}