using System;
using System.Collections.Generic;
using Gameplay.Configs.Meta.Wallet;
using Meta.Features.Counters;
using Meta.Features.Wallet;
using Utilities.ConfigsManagment;

namespace Utilities.DataManagment.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigProviderService _configsProviderService;

        public PlayerDataProvider (
            ISaveLoadService saveLoadSerivce, 
            ConfigProviderService configsProviderService) : base(saveLoadSerivce)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
                CountersData = InitCountersData(),
            };
        }

        private Dictionary<CurrencyType, int> InitWalletData()
        {
            Dictionary<CurrencyType, int> walletData = new();

            StartWalletConfig walletConfig = _configsProviderService.GetConfig<StartWalletConfig>();

            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                walletData[currencyType] = walletConfig.GetValueFor(currencyType);

            return walletData;
        }

        private Dictionary<CounterType, int> InitCountersData()
        {
            Dictionary<CounterType, int> countersData = new();

            foreach (CounterType counterType in Enum.GetValues(typeof(CounterType)))
                countersData[counterType] = 0;

            return countersData;
        }
    }
}