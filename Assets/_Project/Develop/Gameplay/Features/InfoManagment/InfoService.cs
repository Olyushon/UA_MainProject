using System;
using Meta.Features.Counters;
using Meta.Features.Wallet;
using UnityEngine;

namespace Gameplay.Features.InfoManagment   
{
    public class InfoService
    {
        private readonly KeyCode _countersInfoKey = KeyCode.I;
        private readonly KeyCode _walletInfoKey = KeyCode.W;
        private readonly CountersDataService _countersDataService;
        private readonly WalletService _walletService;

        public InfoService(CountersDataService countersDataService, WalletService walletService)
        {
            _countersDataService = countersDataService;
            _walletService = walletService;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(_countersInfoKey))
            {
                foreach (CounterType counterType in Enum.GetValues(typeof(CounterType)))
                {
                    Debug.Log($"{counterType}: {_countersDataService.GetCount(counterType).Value}");
                }
            }
            else if (Input.GetKeyDown(_walletInfoKey))
            {
                foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                {
                    Debug.Log($"{currencyType}: {_walletService.GetCurrency(currencyType).Value}");
                }
            }
        }
    }
}
