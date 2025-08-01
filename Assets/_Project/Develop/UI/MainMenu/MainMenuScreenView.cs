using UI.CommonViews;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public TitleValueListView CountersView { get; private set; }
    }
}
