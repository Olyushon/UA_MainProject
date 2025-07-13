using System;
using Gameplay.Configs.Meta.Wallet;
using Meta.Features.Wallet;
using Utilities.ConfigsManagment;

namespace Gameplay.Features.CostsManagment
{
    public class CostsCalculateService
    {
        private readonly CurrencyType _currencyType = CurrencyType.Gold;
        private readonly WalletService _walletService;
        private readonly CostsConfig _costsConfig;

        public CostsCalculateService(WalletService walletService, ConfigProviderService configsProviderService)
        {
            _walletService = walletService;
            _costsConfig = configsProviderService.GetConfig<CostsConfig>();
        }

        public void AddWinCost()
        {
            _walletService.Add(_currencyType, _costsConfig.WinCost);
        }

        public void TrySpendLoseCost()
        {
            if (_walletService.Enough(_currencyType, _costsConfig.LoseCost) == false)
                throw new InvalidOperationException("Not enough: " + _currencyType.ToString());

            _walletService.Spend(_currencyType, _costsConfig.LoseCost);
        }

        public bool TrySpendResetCost()
        {
            if (_walletService.Enough(_currencyType, _costsConfig.ResetCost))
            {
                _walletService.Spend(_currencyType, _costsConfig.ResetCost);
                return true;
            }

            return false;
        }
    }
}

