using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuEventHandler : MonoBehaviour
    {

        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _settingsButtons;
        [SerializeField] private Button _quitButton;
        
        private void Awake()
        {
            _newGameButton.onClick.AddListener(OnNewGameButtonPressed);
            _continueButton.onClick.AddListener(OnContinueButtonPressed);
            _settingsButtons.onClick.AddListener(OnSettingsButtonPressed);
            _quitButton.onClick.AddListener(OnExitButtonPressed);
        }
        
        private void OnNewGameButtonPressed()
        {
        }

        private void OnContinueButtonPressed()
        {
        }
        
        private void OnSettingsButtonPressed()
        {
            SceneManager.LoadScene("SettingsScene");
        }
        
        private void OnExitButtonPressed()
        {
            PopupConstructor.Instance.Open("Подтвердите свои действия!",
                "Вы уверены что хотите выйти?",
                ()=>Application.Quit());
        }
        
    }
}