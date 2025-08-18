using System.Collections;
using UnityEngine;
using Infrastructure.DI;
using Utilities.SceneManagment;
using Utilities.LoadingScreen;
using Utilities.CoroutinesManagment;
using Utilities.ConfigsManagment;
using Utilities.DataManagment.DataProviders;
using Gameplay.Infrastructure;
using Gameplay.Features.SequenceManagment;

namespace Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            SetupAppSettings();

            DIContainer projectContainer = new DIContainer();

            ProjectContextRegistrations.Process(projectContainer);

            projectContainer.Initialize();

            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            loadingScreen.Show();

            yield return container.Resolve<ConfigProviderService>().LoadAsync();

            bool isPlayerDataSaveExists = false;

            yield return playerDataProvider.Exists(result => isPlayerDataSaveExists = result);

            if (isPlayerDataSaveExists)
                yield return playerDataProvider.Load();
            else
                playerDataProvider.Reset();

            yield return new WaitForSeconds(1f);

            loadingScreen.Hide();

            // yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(SequenceType.Numbers));
        }
    }
}
