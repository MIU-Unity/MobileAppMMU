using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelLoader : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("GameFlatScene");
        }
    }
}