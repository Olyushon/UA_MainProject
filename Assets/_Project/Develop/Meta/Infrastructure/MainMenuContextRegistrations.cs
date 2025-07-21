using Infrastructure.DI;
using Gameplay.Features.GameModeManagment;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using Gameplay.Features.InfoManagment;
using Meta.Features.Counters;
using Meta.Features.Wallet;
using Gameplay.Features.ResetProgressManagment;
using Gameplay.Features.CostsManagment;

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
    }
}