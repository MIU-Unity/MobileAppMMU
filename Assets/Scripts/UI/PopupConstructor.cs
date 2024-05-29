using System;
using Common.Utility;
using JetBrains.Annotations;
using Plugins.DebugAttribute;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public enum PopupType {Clear, WithButtons}
    
    public class PopupConstructor : Singleton<PopupConstructor>
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private PopupClear _popupClearPrefab;
        [SerializeField] private PopupWithButtons _popupWithButtonsPrefab;

        private Popup _currentPopup;
        
        [Debug("Test Popup", "This is a test popup", PopupType.Clear, null)]
        public void Open(string label, string text, PopupType type, [CanBeNull] Action callback = null)
        {
            switch (type)
            {
                case PopupType.Clear:
                    var current = Instantiate(_popupClearPrefab, _canvas.transform);
                    current.Initialize(label, text,
                        () =>
                        {
                            callback?.Invoke();
                            Close();
                        });
                    _currentPopup = current;
                    break;
                case PopupType.WithButtons:
                    var popup = Instantiate(_popupWithButtonsPrefab, _canvas.transform);
                    popup.Initialize(label, text,
                        () =>
                        {
                            callback?.Invoke();
                            Close();
                        },
                        Close);
                    _currentPopup = popup;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

        }


        private void Close() => _currentPopup?.End();

    }
}