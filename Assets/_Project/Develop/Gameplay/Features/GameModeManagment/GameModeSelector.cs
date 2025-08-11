using Gameplay.Features.SequenceManagment;
using Gameplay.Infrastructure;
using UnityEngine;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;

namespace Gameplay.Features.GameModeManagment
{
    public class GameModeSelector
    {
        private KeyCode _digitModeKey = KeyCode.Alpha1;
        private KeyCode _lettersModeKey = KeyCode.Alpha2;
        private readonly string _startMessage = "Select game mode: {0} - Numbers, {1} - Letters";

        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public GameModeSelector(
            ICoroutinesPerformer coroutinesPerformer, 
            SceneSwitcherService sceneSwitcherService)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;
        }

        public string StartMessage => string.Format(_startMessage, (char)_digitModeKey, (char)_lettersModeKey);

        public void Update(float deltaTime)
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
