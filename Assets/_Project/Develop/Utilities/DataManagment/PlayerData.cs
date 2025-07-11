using System.Collections.Generic;
using Meta.Features.Wallet;

namespace Utilities.DataManagment
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyType, int> WalletData;
    }
}
