using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.CommonViews
{
    public class ButtonView : MonoBehaviour, IView
    {
        [SerializeField] private Button _button;


        public void SetTitle(string title) => _button.GetComponentInChildren<TextMeshProUGUI>().text = title;

        public void SetOnClick(Action onClick) => _button.onClick.AddListener(() => onClick?.Invoke());

        private void OnDisable() {
            _button.onClick.RemoveAllListeners();
        }
    }
}
