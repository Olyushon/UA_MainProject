using Infrastructure.DI;
using UI.Wallet;
using UI.CommonViews;
using Meta.Features.Wallet;
using Utilities.Reactive;
using Gameplay.Configs.Meta.Wallet;
using UI.Counters;
using Meta.Features.Counters;
using Utilities.ConfigsManagment;

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

    public CounterPresenter CreateCounterPresenter(
            IReadOnlyVariable<int> counter, 
            CounterType counterType, 
            TitleValueView view)
    {
        return new CounterPresenter(counter, counterType, view);
    }
}
