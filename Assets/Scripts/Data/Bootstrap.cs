using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class Bootstrap : MonoBehaviour
    {
        public async void Start()
        {
            await Connection.Instance.Initialize();

            if (!Connection.Instance.Status) return;
            
            await SaveLoadManager.Instance.Load();
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}