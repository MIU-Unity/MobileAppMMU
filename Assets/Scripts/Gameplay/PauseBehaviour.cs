using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utility;
using Plugins.DebugAttribute;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class PauseBehaviour : Singleton<PauseBehaviour>
    {
        public static Action<bool> OnPause;
        
        private bool _isPaused;

        [Debug(true)]
        public void Set(bool value)
        {
            //TODO: когда-нибудь починить
            //if (value == _isPaused)
              //  throw new Exception(string.Format("Pause state is already {0}", value));

            _isPaused = value;

            //TODO: когда-нибудь починить
            //OnPause?.Invoke(value);
            
            // заглушка
            TimerBehaviour.Instance.OnPause(value);
            PausePopup.Instance.OnPause(value);
        }
    }
}