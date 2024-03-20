using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopupConstructor : MonoBehaviour
    {
        public static PopupConstructor Instance { get; private set; }
        
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Popup _popupPrefab;

        private Popup _currentPopup;

        private void Awake()
        {
            if (Instance != null) Destroy(this);
            else Instance = this;
        }

        [ContextMenu("Test Popup")]
        private void TestPopup()
        {
            Open("Test Popup", "This is a test popup", () =>
            {
                Debug.Log("Popup Confirmed");
            });
        }
        
        public void Open(string label, string text, Action callback)
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