using UI.Core;
using UnityEngine;

namespace UI.Gameplay
{
    public class GameplayPopupService : PopupService
    {
        private readonly GameplayUIRoot _uiRoot;

        public GameplayPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory presentersFactory,
            GameplayUIRoot uiRoot)
            : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public ResultPopupPresenter OpenResultPopup()
        {
            ResultPopupView view = ViewsFactory.Create<ResultPopupView>(ViewIDs.ResultPopup, PopupLayer);

            ResultPopupPresenter popup = PresentersFactory.CreateResultPopupPresenter(view);

            popup.Initialize();
            popup.Show();

            OnPopupCreated(popup, view);

            return popup;
        }
    }
}
