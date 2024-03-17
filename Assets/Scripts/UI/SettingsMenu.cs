using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsScreen;
        
        public void OnBackButtonPressed()
        {
            // TODO: saving settings
            
            SceneManager.LoadScene("MainMenuScene");
            // _settingsScreen.SetActive(false);
        }
    }
}