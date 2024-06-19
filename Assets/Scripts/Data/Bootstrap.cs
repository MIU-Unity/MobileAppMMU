using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Start()
        {
            SaveLoadManager.Instance.Load();

            yield return new WaitForSeconds(2);
            
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}