using System;
using Common.Utility;
using Plugins.DebugAttribute;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class PauseBehaviour : Singleton<PauseBehaviour>
    {
        public static Action<bool> OnPause;

        public bool IsPaused { get; private set; } = false;
        
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