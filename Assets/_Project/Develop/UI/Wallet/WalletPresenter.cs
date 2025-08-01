using System.Collections.Generic;
using Meta.Features.Wallet;
using UI.CommonViews;
using UI.Core;

namespace UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly WalletService _walletService;
        private readonly ProjectPresentersFactory _presentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _walletView;

        private readonly List<CurrencyPresenter> _currencyPresenters = new();

        public WalletPresenter(
            WalletService walletService, 
            ProjectPresentersFactory presentersFactory, 
            ViewsFactory viewsFactory, 
            IconTextListView view)
        {
            _walletService = walletService;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _walletView = view;
        }

        public void Initialize()
        {
            foreach (CurrencyType currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewIDs.CurrencyView);

                _walletView.Add(currencyView);

                CurrencyPresenter currencyPresenter = _presentersFactory.CreateCurrencyPresenter(
                    _walletService.GetCurrency(currencyType),
                    currencyType,
                    currencyView);

                currencyPresenter.Initialize();
                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter currencyPresenter in _currencyPresenters)
            {
                _walletView.Remove(currencyPresenter.View);
                _viewsFactory.Release(currencyPresenter.View);
                currencyPresenter.Dispose();
            }

            _currencyPresenters.Clear();
        }
    }
}