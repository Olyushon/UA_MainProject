using Infrastructure;
using Infrastructure.DI;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using System.Collections;
using UnityEngine;
using Gameplay.Features.GameModeManagment;
using Utilities.DataManagment.DataProviders;
using Gameplay.Features.InfoManagment;
using Gameplay.Features.ResetProgressManagment;

namespace Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private readonly string _menuMessage = "Keycodes: I - counters info; W - wallet info; R - reset counters; S - save;"; // Temp
        private DIContainer _container;
        private GameModeSelector _gameModeSelector;
        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _playerDataProvider;
        private InfoService _infoService;
        private ResetCountersService _resetCountersService;


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

            _infoService = _container.Resolve<InfoService>();
            _resetCountersService = _container.Resolve<ResetCountersService>();
        }

        private void Update()
        {
            _gameModeSelector?.Update(Time.deltaTime);

            _infoService?.Update(Time.deltaTime);

            _resetCountersService?.Update(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                Debug.Log("Save");
            }
        }
    }
}