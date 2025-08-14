using TMPro;
using UnityEngine;

namespace UI.CommonViews
{
    public class TitleTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _text;

        public void SetTitle(string text) => _title.text = text;
        public void SetText(string text) => _text.text = text;
    }
}
