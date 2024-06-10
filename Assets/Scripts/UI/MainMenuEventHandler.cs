using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuEventHandler : MonoBehaviour
    {
        
        public void OnNewGameButtonPressed()
        {
            SceneManager.LoadScene("GameFlatScene");
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