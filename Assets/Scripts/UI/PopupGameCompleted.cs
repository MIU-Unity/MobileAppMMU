using Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PopupGameCompleted : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TimeText { get; private set; }

        [SerializeField] private TextMeshProUGUI _labelText;
        
        [SerializeField] private TextMeshProUGUI _nextLVLButtonText;

        
        public void SetNextButtonText(bool success)
        {
            _nextLVLButtonText.text = success ? "Следующий уровень" : "Перезапустить";
        }

        public void SetLabelText(bool success)
        {
            _labelText.text = success ? "Уровнь пройден!" : "Уровень проигран";
        }
        
        public void OnBackToMenuButton()
        {
            SaveLoadManager.Instance.Save();
            SceneManager.LoadScene("MainMenuScene");
        }

        public void OnNextLevelButton()
        {
            GameplayEventHandler.Instance.NextLevelButton();
        }
    }
}