using System.Collections.Generic;
using UI.Core;
using UI.Counters;
using UI.Wallet;

namespace UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;

        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen, 
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPresentersFactory mainMenuPresentersFactory)
        {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _mainMenuPresentersFactory = mainMenuPresentersFactory; 
        }

        public void Initialize()
        {
            CreateWallet();
            CreateCounters();
            CreateResetButton();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void CreateCounters()
        {
            CountersPresenter countersPresenter = _projectPresentersFactory.CreateCountersPresenter(_screen.CountersView);

            _childPresenters.Add(countersPresenter);
        }

        private void CreateResetButton()
        {
            ResetterPresenter resetterPresenter = _mainMenuPresentersFactory.CreateResetterPresenter(_screen.ResetButtonView);
        
            _childPresenters.Add(resetterPresenter);
        }
    }
}
