using System.Collections;
using UnityEngine;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using Gameplay.Features.SequenceManagment;
using Gameplay.Features.UserInputManagment;
using Meta.Features.Counters;
using Gameplay.Features.CostsManagment;
using Unity.VisualScripting;
using Utilities.DataManagment.DataProviders;

namespace Gameplay.Infrastructure
{
    public class GameplayCycle
    {
        private readonly string _startMessage = "Generated sequence: {0}. \n Try to repeat it! \n Press {1} to check your answer";
        private readonly string _winMessage = "You win!";
        private readonly string _loseMessage = "Wrong! Try again. You entered: {0}";
        private readonly string _restartMessage = "Press {0} to restart";

        private KeyCode _restartKey = KeyCode.Space;

        private SequenceService _sequenceService;
        private UserInputService _userInputService;
        private GameplayInputArgs _inputArgs;
        private SceneSwitcherService _sceneSwitcherService;
        private ICoroutinesPerformer _coroutinesPerformer;
        private CountersDataService _countersDataService;
        private CostsCalculateService _costsCalculateService;
        private PlayerDataProvider _playerDataProvider;

        public GameplayCycle(
            GameplayInputArgs inputArgs,
            SequenceService sequenceService, 
            UserInputService userInputService,
            SceneSwitcherService sceneSwitcherService, 
            ICoroutinesPerformer coroutinesPerformer, 
            CountersDataService countersDataService,
            CostsCalculateService costsCalculateService,
            PlayerDataProvider playerDataProvider)
        {
            _inputArgs = inputArgs;
            _sequenceService = sequenceService;
            _userInputService = userInputService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _countersDataService = countersDataService;
            _costsCalculateService = costsCalculateService;
            _playerDataProvider = playerDataProvider;
        }

        public IEnumerator Prepare()
        {
            _sequenceService.GenerateSequenceByType(_inputArgs.SequenceType);
            _userInputService.SetEnterKey(_sequenceService.GetEnterKey());
            _userInputService.OnSequenceInputReceived += HandleUserInput;

            // yield return new WaitForSeconds(6f);
            yield break;
        }

        public void Launch()
        {
            Debug.LogFormat(_startMessage, _sequenceService.Sequence.Value, _sequenceService.GetEnterKey());

            _userInputService.On();
        }

        private void HandleUserInput(string userInput)
        {
            if (userInput == _sequenceService.Sequence.Value)
                HandleWin();
            else
                HandleLose(userInput);
        }

        private void HandleEnd() {
            _userInputService.Off();
            // _userInputService.ResetSequence();
        }

        private void HandleWin() {
            HandleEnd();

            _countersDataService.IncreaseCounter(CounterType.Win);
            _costsCalculateService.AddWinCost();

            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
            Debug.Log("Save");

            Debug.Log(_winMessage);
            Debug.LogFormat(_restartMessage, _restartKey);

            _coroutinesPerformer.StartPerform(WaitForKeyAndGoToMainMenu());
        }

        private void HandleLose(string userInput) {
            HandleEnd();

            _countersDataService.IncreaseCounter(CounterType.Lose);
            _costsCalculateService.TrySpendLoseCost();
            
            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
            Debug.Log("Save");

            Debug.LogFormat(_loseMessage, userInput);
            Debug.LogFormat(_restartMessage, _restartKey);

            _coroutinesPerformer.StartPerform(WaitForKeyAndGoToGameplay());
        }
        
        private IEnumerator WaitForKeyAndGoToMainMenu() {
            yield return new WaitUntil(() => Input.GetKeyDown(_restartKey));
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
        }

        private IEnumerator WaitForKeyAndGoToGameplay() {
            yield return new WaitUntil(() => Input.GetKeyDown(_restartKey));
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, _inputArgs));
        }

        public void Dispose()
        {
            _userInputService.OnSequenceInputReceived -= HandleUserInput;
        }
    }
}
