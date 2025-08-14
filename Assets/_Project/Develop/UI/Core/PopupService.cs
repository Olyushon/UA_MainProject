using System;
using System.Collections.Generic;
using UI.Gameplay;
using UnityEngine;

namespace UI.Core
{
    public abstract class PopupService : IDisposable
    {
        protected readonly ViewsFactory ViewsFactory;

        protected readonly ProjectPresentersFactory PresentersFactory;

        private readonly Dictionary<PopupPresenterBase, PopupViewBase> _presenterToView = new();


        protected PopupService (
            ViewsFactory viewsFactory, 
            ProjectPresentersFactory presentersFactory)
        {
            ViewsFactory = viewsFactory;
            PresentersFactory = presentersFactory;
        }

        protected abstract Transform PopupLayer { get; }

        public void ClosePopup(PopupPresenterBase popup)
        {
            popup.CloseRequest -= ClosePopup;

            popup.Hide(() =>
            {
                DisposeFor(popup);
                _presenterToView.Remove(popup);
            });
        }

        public void Dispose()
        {
            foreach (PopupPresenterBase popup in _presenterToView.Keys)
            {
                popup.CloseRequest -= ClosePopup;
                DisposeFor(popup);
            }

            _presenterToView.Clear();
        }

        protected void OnPopupCreated(
            PopupPresenterBase popup,
            PopupViewBase view)
        {
            _presenterToView.Add(popup, view);
            popup.Initialize();
            popup.Show();

            popup.CloseRequest += ClosePopup;
        }

        private void DisposeFor(PopupPresenterBase popup)
        {
            popup.Dispose();
            ViewsFactory.Release(_presenterToView[popup]);
        }
    }
}