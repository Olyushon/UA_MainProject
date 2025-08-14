using Infrastructure.DI;
using UI.Wallet;
using UI.CommonViews;
using Meta.Features.Wallet;
using Utilities.Reactive;
using Gameplay.Configs.Meta.Wallet;
using UI.Counters;
using Meta.Features.Counters;
using Utilities.ConfigsManagment;
using UI.Gameplay;
using Gameplay.Infrastructure;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;

namespace UI.Core
{
    public class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public CurrencyPresenter CreateCurrencyPresenter(
                IReadOnlyVariable<int> currency, 
                CurrencyType currencyType, 
                IconTextView view)
        {
            return new CurrencyPresenter(
                currency, 
                currencyType, 
                _container.Resolve<ConfigProviderService>().GetConfig<CurrencyIconsConfig>(), 
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView view)
        {
            return new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view
            );
        }

        public CounterPresenter CreateCounterPresenter(
                IReadOnlyVariable<int> counter, 
                CounterType counterType, 
                TitleValueView view)
        {
            return new CounterPresenter(counter, counterType, view);
        }

        public CountersPresenter CreateCountersPresenter(TitleValueListView view)
        {
            return new CountersPresenter(
                _container.Resolve<CountersDataService>(),
                view,
                this,
                _container.Resolve<ViewsFactory>());
        }

        public ResultPopupPresenter CreateResultPopupPresenter(ResultPopupView view)
        {
            return new ResultPopupPresenter(
                view,
                _container.Resolve<GameResultService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<SceneSwitcherService>());
        }
    }
}
