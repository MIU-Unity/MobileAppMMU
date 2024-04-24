using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        public void Initialize(string label, string text, Action onConfirm, Action onCancel)
        {
            _label.text = label;
            _description.text = text;
            _confirmButton.onClick.AddListener(()=> onConfirm.Invoke());
            _cancelButton.onClick.AddListener(() => onCancel.Invoke());
        }

        public void End() => Destroy(this.gameObject, .1f);

        //TODO: анимация через DOTWEEN
    }
}