using Gameplay.Features.CostsManagment;
using Meta.Features.Counters;
using UI.CommonViews;
using UI.Core;
using UnityEngine;
using Utilities.CoroutinesManagment;
using Utilities.DataManagment.DataProviders;

namespace UI.Counters
{
    public class ResetterPresenter : IPresenter
    {
        private readonly string _buttonText = "Reset counters (for {0} {1})";
        private readonly string _notEnoughMoneyForResetMessage = "Not enough money for reset";

        private readonly CostsCalculateService _costsCalculateService;
        private readonly CountersDataService _countersDataService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly ButtonView _view;

        public ResetterPresenter(
            ButtonView view, 
            CostsCalculateService costsCalculateService, 
            CountersDataService countersDataService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _view = view;
            _costsCalculateService = costsCalculateService;
            _countersDataService = countersDataService;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Initialize()
        {
            _view.SetTitle(string.Format(
                _buttonText, 
                _costsCalculateService.ResettingCost, 
                _costsCalculateService.CurrencyType.ToString()));

            _view.SetOnClick(OnResetButtonClicked);
        }

        public void Dispose()
        {
            
        }

        private void OnResetButtonClicked()
        {
            if (_costsCalculateService.TrySpendResetCost() == false)
            {
                Debug.Log(_notEnoughMoneyForResetMessage);
                return;
            }

            _countersDataService.ResetCounters();
            Debug.Log("Counters resetted");

            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
            Debug.Log("Save");
        }
    }
}
