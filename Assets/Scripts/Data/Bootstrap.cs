using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class Bootstrap : MonoBehaviour
    {
        public async void Start()
        {
            SaveLoadManager.Instance.Load();
            await Connection.Instance.Initialize();

            if(Connection.Instance.Status)
                SceneManager.LoadScene("MainMenuScene");
        }
    }
}