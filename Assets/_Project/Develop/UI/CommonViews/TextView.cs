using TMPro;
using UnityEngine;

namespace UI.CommonViews
{
    public class TextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text) => _text.text = text;
    }
}
