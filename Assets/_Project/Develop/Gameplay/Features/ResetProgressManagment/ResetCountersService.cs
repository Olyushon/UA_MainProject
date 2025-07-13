using System.Collections;
using System.Collections.Generic;
using Gameplay.Features.CostsManagment;
using Meta.Features.Counters;
using UnityEngine;

namespace Gameplay.Features.ResetProgressManagment
{
    public class ResetCountersService
    {
        private readonly KeyCode _resetCountersKey = KeyCode.R;
        private readonly string _notEnoughMoneyForResetMessage = "Not enough money for reset";
        private readonly CountersDataService _countersDataService;
        private readonly CostsCalculateService _costsCalculateService;

        public ResetCountersService(
            CountersDataService countersDataService, 
            CostsCalculateService costsCalculateService)
        {
            _countersDataService = countersDataService;
            _costsCalculateService = costsCalculateService;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(_resetCountersKey))
            {
                if (_costsCalculateService.TrySpendResetCost() == false)
                {
                    Debug.Log(_notEnoughMoneyForResetMessage);
                    return;
                }

                _countersDataService.ResetCounters();
                Debug.Log("Counters reset");
            }
        }
    }
}
