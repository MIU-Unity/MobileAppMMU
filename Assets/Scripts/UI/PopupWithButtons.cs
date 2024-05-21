using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopupWithButtons : Popup
    {
        [SerializeField] private Button _cancelButton;

        public void Initialize(string label, string text, Action onConfirm, Action onCancel)
        {
            _label.text = label;
            _description.text = text;
            _confirmButton.onClick.AddListener(()=> onConfirm.Invoke());
            _cancelButton.onClick.AddListener(() => onCancel.Invoke());
        }

    }
}