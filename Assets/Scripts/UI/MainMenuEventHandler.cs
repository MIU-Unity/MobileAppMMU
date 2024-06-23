using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuEventHandler : MonoBehaviour
    {

        [SerializeField] private Button _continueButton;

        private bool _hasProgress;
        public void Start()
        {
            _hasProgress = Level.GetCurrent() != 1;
            
            if(_hasProgress == false)
                _continueButton.interactable = false;
        }
        
        public void OnNewGameButtonPressed()
        {
            if (_hasProgress)
            {
                PopupConstructor.Instance.Open(
                    "Новая игра",
                    "Вы уверены что хотите начать заново? Весь прогресс будет утерян.",
                    PopupType.WithButtons,
                    () =>
                    {
                        Level.SetCurrent(1);
                        SceneManager.LoadScene("GameFlatScene");
                    }
                );
            } else SceneManager.LoadScene("GameFlatScene");
        }

        public void OnContinueButtonPressed()
        {
            SceneManager.LoadScene("GameFlatScene");
        }
        
        public void OnSettingsButtonPressed()
        {
            SceneManager.LoadScene("SettingsScene");
        }
        
        public void OnExitButtonPressed()
        {
            PopupConstructor.Instance.Open("Подтвердите свои действия!",
                "Вы уверены что хотите выйти?",
                PopupType.WithButtons,
                ()=>Application.Quit());
        }
        
    }
}