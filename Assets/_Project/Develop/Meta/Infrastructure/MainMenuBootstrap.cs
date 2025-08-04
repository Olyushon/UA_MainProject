using Infrastructure;
using Infrastructure.DI;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using System.Collections;
using UnityEngine;
using Gameplay.Features.GameModeManagment;
using Utilities.DataManagment.DataProviders;

namespace Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private readonly string _menuMessage = "Keycodes: S - save;"; // Temp
        private DIContainer _container;
        private GameModeSelector _gameModeSelector;
        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _playerDataProvider;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            _playerDataProvider = _container.Resolve<PlayerDataProvider>();

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Main menu scene");
            Debug.Log(_menuMessage);

            _gameModeSelector = _container.Resolve<GameModeSelector>();
            _gameModeSelector.Start();
        }

        private void Update()
        {
            _gameModeSelector?.Update(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                Debug.Log("Save");
            }
        }
    }
}