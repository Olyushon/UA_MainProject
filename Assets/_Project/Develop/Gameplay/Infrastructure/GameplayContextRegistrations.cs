using Infrastructure.DI;
using Utilities.AssetsManagment;
using Gameplay.Features.SequenceManagment;
using Gameplay.Features.UserInputManagment;
using UI.Gameplay;
using UnityEngine;
using UI.Core;
using Gameplay.EntitiesCore;

namespace Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateSequenceService).NonLazy();
            container.RegisterAsSingle(CreateUserInputService);

            container.RegisterAsSingle(CreateGameplayUIRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresentersFactory);
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();

            container.RegisterAsSingle(CreateGameplayPopupService);

            container.RegisterAsSingle(CreateEntitiesFactory);
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
        {
            return new EntitiesFactory(c);
        }

        private static GameplayPopupService CreateGameplayPopupService(DIContainer c)
        {
            return new GameplayPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<GameplayUIRoot>());
        }

        private static GameplayUIRoot CreateGameplayUIRoot(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            GameplayUIRoot gameplayUIRootPrefab = resourcesLoader.Load<GameplayUIRoot>("UI/Gameplay/GameplayUIRoot");

            return Object.Instantiate(gameplayUIRootPrefab);
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory(DIContainer c)
        {
            return new GameplayPresentersFactory(c);
        }

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer c)
        {
            GameplayUIRoot uiRoot = c.Resolve<GameplayUIRoot>();

            GameplayScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewIDs.GameplayScreen, uiRoot.HUDLayer);

            GameplayScreenPresenter presenter = c
                .Resolve<GameplayPresentersFactory>()
                .CreateGameplayScreen(view);

            return presenter;
        }   

        private static SequenceService CreateSequenceService(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            SequenceMainConfig sequenceMainConfig = resourcesLoader
                .Load<SequenceMainConfig>("Configs/SequenceMainConfig");

            return new SequenceService(sequenceMainConfig, resourcesLoader);
        }

        private static UserInputService CreateUserInputService(DIContainer c)
        {
            return new UserInputService();
        }
    }
}