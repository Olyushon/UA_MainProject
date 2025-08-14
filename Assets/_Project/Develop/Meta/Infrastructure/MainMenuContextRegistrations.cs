using Infrastructure.DI;
using Gameplay.Features.GameModeManagment;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using UnityEngine;
using UI.Core;
using Utilities.AssetsManagment;
using UI.MainMenu;

namespace Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            // Debug.Log("Процесс регистрации сервисов на сцене меню");

            container.RegisterAsSingle(CreateGameModeSelector);

            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
        }

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            MainMenuUIRoot mainMenuUIRootPrefab = resourcesLoader.Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }

        private static GameModeSelector CreateGameModeSelector(DIContainer c)
        {
            return new GameModeSelector(
                c.Resolve<ICoroutinesPerformer>(), 
                c.Resolve<SceneSwitcherService>());
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer c)
        {
            return new MainMenuPresentersFactory(c);
        }

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            MainMenuUIRoot uiRoot = c.Resolve<MainMenuUIRoot>();

            MainMenuScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, uiRoot.HUDLayer);

            MainMenuScreenPresenter presenter = c
                .Resolve<MainMenuPresentersFactory>()
                .CreateMainMenuScreen(view);

            return presenter;
        }
    }
}