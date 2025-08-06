using System;
using System.Collections.Generic;
using UI.CommonViews;
using UnityEngine;
using Utilities.AssetsManagment;
using Object = UnityEngine.Object;

namespace UI.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesLoader _resourcesLoader;

        private readonly Dictionary<string, string> _viewIDToResourcesPath = new Dictionary<string, string>()
        {
            {ViewIDs.CurrencyView, "UI/Wallet/CurrencyView"},
            {ViewIDs.CounterView, "UI/Counters/CounterView"},
            {ViewIDs.MainMenuScreen, "UI/MainMenu/MainMenuScreenView"},
            {ViewIDs.GameplayScreen, "UI/Gameplay/GameplayScreenView"}
        };

        public ViewsFactory(ResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public TView Create<TView>(string viewID, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (_viewIDToResourcesPath.TryGetValue(viewID, out string resourcePath) == false)
                throw new ArgumentException($"You didn't set resource path for {typeof(TView)}, searched id: {viewID}");

            GameObject prefab = _resourcesLoader.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefab, parent);
            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)} component on view instance");

            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
        {
            Object.Destroy(view.gameObject);
        }
    }
}
