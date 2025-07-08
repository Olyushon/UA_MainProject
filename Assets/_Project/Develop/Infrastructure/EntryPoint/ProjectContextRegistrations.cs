using Infrastructure.DI;
using Utilities.SceneManagment;
using Utilities.LoadingScreen;
using Utilities.CoroutinesManagment;
using Object = UnityEngine.Object;
using Utilities.AssetsManagment;
using Utilities.ConfigsManagment;

namespace Infrastructure.EntryPoint
{
    public class ProjectContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);

            container.RegisterAsSingle(CreateResourcesLoader);

            container.RegisterAsSingle(CreateConfigsProviderService);

            container.RegisterAsSingle(CreateSceneLoaderService);

            container.RegisterAsSingle(CreateSceneSwitcherService);

            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
        }

        private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            CoroutinesPerformer coroutinesPerformerPrefab = resourcesLoader
                .Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }

        private static ResourcesLoader CreateResourcesLoader(DIContainer c)
            => new ResourcesLoader();

        private static ConfigProviderService CreateConfigsProviderService(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(resourcesLoader);

            return new ConfigProviderService(resourcesConfigsLoader);
        }
        
        private static SceneLoaderService CreateSceneLoaderService(DIContainer c)
            => new SceneLoaderService();

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer c)
            => new SceneSwitcherService(
                c.Resolve<SceneLoaderService>(),
                c.Resolve<ILoadingScreen>(),
                c);

        private static StandardLoadingScreen CreateLoadingScreen(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            StandardLoadingScreen standardLoadingScreenPrefab = resourcesLoader
                .Load<StandardLoadingScreen>("Utilities/StandardLoadingScreen");

            return Object.Instantiate(standardLoadingScreenPrefab);
        }
    }
}