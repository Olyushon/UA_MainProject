using Infrastructure.DI;
using Gameplay.Features.GameModeManagment;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using Gameplay.Features.InfoManagment;
using Meta.Features.Counters;
using Meta.Features.Wallet;
using Gameplay.Features.ResetProgressManagment;
using Gameplay.Features.CostsManagment;
using UI.Wallet;
using UI.CommonViews;
using UnityEngine;
using UI.Core;
using UI.Counters;

namespace Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            // Debug.Log("Процесс регистрации сервисов на сцене меню");

            container.RegisterAsSingle(CreateGameModeSelector);
            container.RegisterAsSingle(CreateInfoService);
            container.RegisterAsSingle(CreateResetCountersService);

            container.RegisterAsSingle(CreateWalletPresenter).NonLazy();
            container.RegisterAsSingle(CreateCountersPresenter).NonLazy();
        }

        private static GameModeSelector CreateGameModeSelector(DIContainer c)
        {
            return new GameModeSelector(
                c.Resolve<ICoroutinesPerformer>(), 
                c.Resolve<SceneSwitcherService>());
        }

        private static InfoService CreateInfoService(DIContainer c)
        {
            return new InfoService(
                c.Resolve<CountersDataService>(), 
                c.Resolve<WalletService>());
        }

        private static ResetCountersService CreateResetCountersService(DIContainer c)
        {
            return new ResetCountersService(
                c.Resolve<CountersDataService>(), 
                c.Resolve<CostsCalculateService>());
        }

        private static WalletPresenter CreateWalletPresenter(DIContainer c)
        {
            IconTextListView walletView = Object.FindObjectOfType<IconTextListView>();

            WalletPresenter walletPresenter = c.Resolve<ProjectPresentersFactory>().CreateWalletPresenter(walletView);

            return walletPresenter;
        }

        private static CountersPresenter CreateCountersPresenter(DIContainer c)
        {
            TitleValueListView countersView = Object.FindObjectOfType<TitleValueListView>();

            CountersPresenter countersPresenter = c.Resolve<ProjectPresentersFactory>().CreateCountersPresenter(countersView);

            return countersPresenter;
        }
    }
}