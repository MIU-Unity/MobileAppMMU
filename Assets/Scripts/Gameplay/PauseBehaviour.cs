using System;
using Plugins.DebugAttribute;
using UnityEngine;

namespace Gameplay
{
    public class PauseBehaviour : MonoBehaviour
    {
        public static PauseBehaviour Instance { get; private set; }
        
        public static Action<bool> OnPause;

        private bool _isPaused = false;
        
        private void Awake()
        {
            if (Instance != null && Instance.GetInstanceID() != this.GetInstanceID())
            {
                throw new Exception(string.Format("Instance of {0} is already exist",this.name));
            }

            Instance = this;
        }
        
        [Debug(true)]
        public void Set(bool value)
        {
            if (value == _isPaused) 
                throw new Exception(string.Format("Pause state is already {0}",value));

            _isPaused = value;
            OnPause?.Invoke(value);
        }
    }
}