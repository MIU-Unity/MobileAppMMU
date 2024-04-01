using System;
using Gameplay;
using Plugins.DebugAttribute;
using UnityEngine;

namespace UI
{
    public class GameplayEventHandler : MonoBehaviour
    {
        public static GameplayEventHandler Instance { get; private set; }
        
        [SerializeField] private PausePopup _pausePopup;

        private void Awake()
        {
            if (Instance != null && Instance.GetInstanceID() != this.GetInstanceID())
            {
                throw new Exception(string.Format("Instance of {0} is already exist",this.name));
            }

            Instance = this;
        }

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