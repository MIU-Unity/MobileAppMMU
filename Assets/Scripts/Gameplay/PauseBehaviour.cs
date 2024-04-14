using System;
using Plugins.DebugAttribute;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class PauseBehaviour : MonoBehaviour
    {
        public static PauseBehaviour Instance { get; private set; }
        
        public static Action<bool> OnPause;

        public bool IsPaused { get; private set; } = false;
        
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
            if (value == IsPaused) 
                throw new Exception(string.Format("Pause state is already {0}",value));

            IsPaused = value;
            OnPause?.Invoke(value);
        }
    }
}