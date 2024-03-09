using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Popup : MonoBehaviour
    {
        public TextMeshProUGUI Label { get; private set; }
        public TextMeshProUGUI Text { get; private set; }
        public Button ConfirmButton { get; private set; }
        public Button CancelButton { get; private set; }

        public void Initialize(string label, string text, Action OnConfirm, Action OnCancel)
        {
            Label.text = label;
            Text.text = text;
            ConfirmButton.onClick.AddListener(()=> OnConfirm.Invoke());
            CancelButton.onClick.AddListener(() => OnCancel.Invoke());
        }

        public void End() => Destroy(this.gameObject, .1f);

        //TODO: анимация через DOTWEEN
    }
}