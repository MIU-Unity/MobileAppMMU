using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class Popup : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _label;
        [SerializeField] protected TextMeshProUGUI _description;
        [SerializeField] protected Button _confirmButton;
        
        public void End() => Destroy(this.gameObject, .1f);

    }
}