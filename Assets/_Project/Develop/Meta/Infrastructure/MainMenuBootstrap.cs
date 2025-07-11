using Infrastructure;
using Infrastructure.DI;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using System.Collections;
using UnityEngine;
using Gameplay.Features.GameModeManagment;

namespace Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameModeSelector _gameModeSelector;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            yield break;
        }

        public override void Run()
        {
            Debug.Log("Main menu scene");

            _gameModeSelector = new GameModeSelector(
                _container.Resolve<ICoroutinesPerformer>(), 
                _container.Resolve<SceneSwitcherService>());

            _gameModeSelector.Start();
        }

        private void Update()
        {
            _gameModeSelector?.Update(Time.deltaTime);
        }
    }
}