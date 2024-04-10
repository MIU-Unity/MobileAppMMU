using System;
using Common.Utility;
using Plugins.DebugAttribute;
using UnityEngine;

namespace Gameplay
{
    public class PauseBehaviour : Singleton<PauseBehaviour>
    {
        public static Action<bool> OnPause;

        private bool _isPaused = false;
        
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