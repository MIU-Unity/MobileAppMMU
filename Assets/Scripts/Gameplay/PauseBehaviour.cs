using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utility;
using Interfaces;
using Plugins.DebugAttribute;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class PauseBehaviour : Singleton<PauseBehaviour>
    {
        private bool _isPaused = false;

        [Debug(true)]
        public void Set(bool value)
        {
            if (value == _isPaused)
                throw new Exception(string.Format("Pause state is already {0}", value));

            _isPaused = value;

            List<ICanBePaused> objectsToPause = FindObjectsOfType<MonoBehaviour>(true).OfType<ICanBePaused>().ToList();
            objectsToPause.ForEach(o => o.OnPause(value));
        }
    }
}