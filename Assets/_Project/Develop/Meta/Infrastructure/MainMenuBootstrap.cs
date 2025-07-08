using Infrastructure;
using Infrastructure.DI;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using Utilities.SequenceManagment;
using Gameplay.Infrastructure;
using System.Collections;
using UnityEngine;

namespace Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private KeyCode _digitModeKey = KeyCode.Alpha1;
        private KeyCode _lettersModeKey = KeyCode.Alpha2;
        private readonly string _startMessage = "Select game mode: {0} - Numbers, {1} - Letters";

        private DIContainer _container;
        private SceneSwitcherService _sceneSwitcherService;
        private ICoroutinesPerformer _coroutinesPerformer;

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

            _sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();

            Debug.LogFormat(_startMessage, (char)_digitModeKey, (char)_lettersModeKey);
        }

        private void Update()
        {
            if (Input.GetKeyDown(_digitModeKey))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(
                    Scenes.Gameplay, 
                    new GameplayInputArgs(SequenceType.Numbers)));
            }
            else if (Input.GetKeyDown(_lettersModeKey))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(
                    Scenes.Gameplay, 
                    new GameplayInputArgs(SequenceType.Letters)));
            }
        }
    }
}