using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _diffucultyButtonText;
        [SerializeField] private Image _diffucultyButtonImage;
        [SerializeField] private Sprite[] _diffucultyButtonSprites;
        
        public void OnBackButtonPressed()
        {
            SaveLoadManager.Instance.Save();
            SceneManager.LoadScene("MainMenuScene");
        }

        public void OnDifficultButtonPressed()
        {
            int current = Difficult.Get();
            current++;
            if (current > Difficult.MAX_DIFFICULTY)
                current = 1;

            Difficult.Set(current);
            _diffucultyButtonImage.sprite = _diffucultyButtonSprites[current - 1];
            _diffucultyButtonText.text = "Сложность: " + Difficult.GetName();
            
        }
        
        public void OnResetButtonPressed()
        {
            PopupConstructor.Instance.Open(
                "Сброс.",
                "Вы уверены что хотите сбросить данные игры? Весь прогресс будет утерян.",
                PopupType.WithButtons,
                () =>
                {
                    SaveLoadManager.Instance.Reset();
                    SceneManager.LoadScene("MainMenuScene");
                });
        }
    }
}