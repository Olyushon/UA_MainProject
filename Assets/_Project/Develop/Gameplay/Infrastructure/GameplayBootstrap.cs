using Infrastructure;
using Infrastructure.DI;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using Gameplay.Features.SequenceManagment;
using System;
using System.Collections;
using UnityEngine;
using Gameplay.Features.UserInputManagment;
using Meta.Features.Counters;
using Gameplay.Features.CostsManagment;

namespace Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private readonly string _modeMessage = "Selected sequence type: {0}";
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private GameplayCycle _gameplayCycle;
        private UserInputService _userInputService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.LogFormat(_modeMessage, _inputArgs.SequenceType);

            _userInputService = _container.Resolve<UserInputService>();
            _gameplayCycle = new GameplayCycle(
                _inputArgs,
                _container.Resolve<SequenceService>(),
                _userInputService,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<CountersDataService>(),
                _container.Resolve<CostsCalculateService>());

            yield return _gameplayCycle.Prepare();
        }

        public override void Run()
        {
            Debug.Log("Gameplay scene");

            _gameplayCycle.Launch();
        }

        private void Update()
        {
            _userInputService?.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _gameplayCycle.Dispose();
        }
    }
}