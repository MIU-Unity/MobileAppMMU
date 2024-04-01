using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PausePopup : MonoBehaviour
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
            _resumeButton.onClick.AddListener(() => PauseBehaviour.Instance.Set(false));
            _backToMenuButton.onClick.AddListener(() =>
                PopupConstructor.Instance.Open(
                    "Выйти в меню",
                    "Вы уверены, что хотите выйти в меню? Весь несохраненный прогресс будет удален.",
                    () => SceneManager.LoadScene("MainMenuScene"))
                );
            
            //TODO: Add settings button
            // _settingsButton.onClick.AddListener(() => OnSettingsButtonClicked()?.Invoke();
            _isFirstOpen = false;
        }
    }
}