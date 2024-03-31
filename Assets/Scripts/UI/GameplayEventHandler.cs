using Gameplay;
using Plugins.DebugAttribute;
using UnityEngine;

namespace UI
{
    public class GameplayEventHandler : MonoBehaviour
    {
        [SerializeField] private PausePopup _pausePopup;
        
        [Debug]
        public void Initialize()
        {
            PauseBehaviour.OnPause += OnPause;
            Debug.Log("GameplayEventHandler initialized");
        }

        private void OnPause(bool value)
        {
            Debug.Log("OnPause: " + value);
            if (value)
            {
                _pausePopup.Open();
            }
            else
            {
                _pausePopup.Close();
            }
            
        }
    }
}