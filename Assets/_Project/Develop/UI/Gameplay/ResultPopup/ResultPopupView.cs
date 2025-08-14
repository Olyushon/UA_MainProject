using System;
using TMPro;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay
{
    public class ResultPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        public void SetText(string text) => _text.text = text;

        public void SetButtonTitle(string title) => _button.GetComponentInChildren<TextMeshProUGUI>().text = title;
        public void SetOnClick(Action onClick) => _button.onClick.AddListener(() => onClick?.Invoke());
    }
}
