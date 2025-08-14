using System.Collections;
using Utilities.CoroutinesManagment;
using Gameplay.Features.SequenceManagment;
using Gameplay.Features.UserInputManagment;
using Meta.Features.Counters;
using Gameplay.Features.CostsManagment;
using Utilities.DataManagment.DataProviders;
using UI.Gameplay;

namespace Gameplay.Infrastructure
{
    public class GameplayCycle
    {
        private SequenceService _sequenceService;
        private UserInputService _userInputService;
        private GameplayInputArgs _inputArgs;
        private ICoroutinesPerformer _coroutinesPerformer;
        private CountersDataService _countersDataService;
        private CostsCalculateService _costsCalculateService;
        private PlayerDataProvider _playerDataProvider;
        private GameResultService _gameResultService;
        private GameplayPopupService _gameplayPopupService;

        public GameplayCycle(
            GameplayInputArgs inputArgs,
            SequenceService sequenceService, 
            UserInputService userInputService,
            ICoroutinesPerformer coroutinesPerformer, 
            CountersDataService countersDataService,
            CostsCalculateService costsCalculateService,
            PlayerDataProvider playerDataProvider,
            GameResultService gameResultService,
            GameplayPopupService gameplayPopupService)
        {
            _inputArgs = inputArgs;
            _sequenceService = sequenceService;
            _userInputService = userInputService;
            _coroutinesPerformer = coroutinesPerformer;
            _countersDataService = countersDataService;
            _costsCalculateService = costsCalculateService;
            _playerDataProvider = playerDataProvider;   
            _gameResultService = gameResultService;
            _gameplayPopupService = gameplayPopupService;
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

            _gameResultService.SetWinResult();
            _gameplayPopupService.OpenResultPopup();
        }

        private void HandleLose(string userInput) {
            HandleEnd();

            _countersDataService.IncreaseCounter(CounterType.Lose);
            _costsCalculateService.TrySpendLoseCost();
            
            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());

            _gameResultService.SetLoseResult(_inputArgs);
            _gameplayPopupService.OpenResultPopup();
        }
        
        public void Dispose()
        {
            _userInputService.OnSequenceInputReceived -= HandleUserInput;
        }
    }
}
