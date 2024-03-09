using System;
using UnityEngine;
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
            MainMenuEventHub.OnNewGameButtonPressedAction += OnNewGameButtonPressedAction;
            MainMenuEventHub.OnContinueButtonPressedAction += OnContinueButtonPressedAction;
            MainMenuEventHub.OnSettingsButtonPressedAction += OnSettingsButtonPressedAction;
            MainMenuEventHub.OnExitButtonPressedAction += OnExitButtonPressedAction;
            
            _newGameButton.onClick.AddListener(MainMenuEventHub.NewGameButtonPressed);
            _continueButton.onClick.AddListener(MainMenuEventHub.ContinueButtonPressed);
            _settingsButtons.onClick.AddListener(MainMenuEventHub.SettingsButtonPressed);
            _quitButton.onClick.AddListener(MainMenuEventHub.ExitButtonPressed);
        }
        
        private void OnNewGameButtonPressedAction()
        {
        }

        private void OnContinueButtonPressedAction()
        {
        }
        
        private void OnSettingsButtonPressedAction()
        {
        }
        
        private void OnExitButtonPressedAction()
        {
            PopupConstructor.Instance.Open("Confirm your actions!",
                "Are you sure you want to close the application?",
                ()=>Application.Quit());
        }
        
    }
}