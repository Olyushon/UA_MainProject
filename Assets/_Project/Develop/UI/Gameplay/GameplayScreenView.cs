using UI.CommonViews;
using UnityEngine;

namespace UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public TitleTextView GeneratedStringView { get; private set; }
        [field: SerializeField] public TitleTextView UserInputStringView { get; private set; }
        
    }
}
