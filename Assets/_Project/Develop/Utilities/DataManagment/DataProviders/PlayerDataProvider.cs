using System.Collections.Generic;
using Meta.Features.Wallet;
using Utilities.DataManagment;

namespace Utilities.DataManagment.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        public PlayerDataProvider(ISaveLoadService saveLoadSerivce) : base(saveLoadSerivce)
        {
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
            };
        }

        private Dictionary<CurrencyType, int> InitWalletData()
        {
            Dictionary<CurrencyType, int> walletData = new();

            walletData.Add(CurrencyType.Gold, 100);

            return walletData;
        }
    }
}