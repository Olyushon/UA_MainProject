using Gameplay.Features.CostsManagment;
using Gameplay.Features.GameModeManagment;
using Infrastructure.DI;
using Meta.Features.Counters;
using UI.CommonViews;
using UI.Core;
using UI.Counters;
using Utilities.CoroutinesManagment;
using Utilities.DataManagment.DataProviders;

namespace UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreen(MainMenuScreenView view)
        {
            return new MainMenuScreenPresenter(
                view, 
                _container.Resolve<ProjectPresentersFactory>(),
                this);
        }

        public ResetterPresenter CreateResetterPresenter(ButtonView buttonView) 
        {
            return new ResetterPresenter(
                buttonView,
                _container.Resolve<CostsCalculateService>(),
                _container.Resolve<CountersDataService>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public SelectModeTextPresenter CreateSelectModeTextPresenter(TextView textView)
        {
            return new SelectModeTextPresenter(textView, _container.Resolve<GameModeSelector>());
        }
    }
}
