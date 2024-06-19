using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopupClear : Popup
    {
        public void Initialize(string label, string text, Action onConfirm)
        {
            _label.text = label;
            _description.text = text;
            _confirmButton.onClick.AddListener(()=> onConfirm.Invoke());
        }

    }
}