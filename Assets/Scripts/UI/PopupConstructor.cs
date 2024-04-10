using System;
using Common.Utility;
using JetBrains.Annotations;
using Plugins.DebugAttribute;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopupConstructor : Singleton<PopupConstructor>
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Popup _popupPrefab;

        private Popup _currentPopup;


        [Debug("Test Popup", "This is a test popup", null)]
        public void Open(string label, string text, [CanBeNull] Action callback)
        {
            _currentPopup = Instantiate(_popupPrefab, _canvas.transform);
            _currentPopup.Initialize(label, text,
                () =>
                {
                    callback?.Invoke();
                    Close();
                },
                Close);
        }


        private void Close() => _currentPopup?.End();

    }
}