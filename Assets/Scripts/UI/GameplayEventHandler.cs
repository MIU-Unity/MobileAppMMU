using System;
using Common.Utility;
using Gameplay;
using Plugins.DebugAttribute;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameplayEventHandler : Singleton<GameplayEventHandler>
    {
        [SerializeField] private Button _hintButton;
        [SerializeField] private Button _pauseButton;

        public void Initialize()
        {
            _pauseButton.onClick.AddListener(() => PauseBehaviour.Instance.Set(true));
            Debug.Log("GameplayEventHandler initialized");
        }

        public void OnDestroy()
        {
            Debug.Log("GameplayEventHandler destroyed");
        }
        
        
    }
}