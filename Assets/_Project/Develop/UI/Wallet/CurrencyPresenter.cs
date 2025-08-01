using System;
using Gameplay.Configs.Meta.Wallet;
using Meta.Features.Wallet;
using UI.CommonViews;
using UI.Core;
using UnityEngine;
using Utilities.Reactive;

namespace UI.Wallet
{
    public class CurrencyPresenter : IPresenter
    {
        //Бизнес логика
        private readonly IReadOnlyVariable<int> _currency;
        private readonly CurrencyType _currencyType;
        private readonly CurrencyIconsConfig _currencyIconsConfig;

        //Визуал
        private readonly IconTextView _view;

        private IDisposable _currencySubscription;

        public CurrencyPresenter(
            IReadOnlyVariable<int> currency, 
            CurrencyType currencyType, 
            CurrencyIconsConfig currencyIconsConfig, 
            IconTextView view)
        {
            _currency = currency;
            _currencyType = currencyType;
            _currencyIconsConfig = currencyIconsConfig;
            _view = view;
        }

        public IconTextView View => _view;
        
        public void Initialize() {
            UpdateValue(_currency.Value);
            _view.SetIcon(_currencyIconsConfig.GetSpriteFor(_currencyType));

            _currencySubscription = _currency.Subscribe(OnCurrencyChanged);
        }

        public void Dispose() {
            _currencySubscription?.Dispose();
        }

        private void OnCurrencyChanged(int oldValue, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}