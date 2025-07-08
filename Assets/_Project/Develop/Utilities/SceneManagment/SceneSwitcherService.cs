using System.Collections;
using Utilities.LoadingScreen;
using Infrastructure;
using Infrastructure.DI;
using System;
using Object = UnityEngine.Object;

namespace Utilities.SceneManagment
{
    public class SceneSwitcherService
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly ILoadingScreen _loadingScreen;
        private readonly DIContainer _projectContainer;

        public SceneSwitcherService(
            SceneLoaderService sceneLoaderService, 
            ILoadingScreen loadingScreen,
            DIContainer projectContainer)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _projectContainer = projectContainer;
        }

        public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            yield return _sceneLoaderService.LoadAsync(Scenes.Empty);
            yield return _sceneLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindObjectOfType<SceneBootstrap>();

            if (sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            DIContainer sceneContainer = new DIContainer(_projectContainer);

            sceneBootstrap.ProcessRegistrations(sceneContainer, sceneArgs);

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}
