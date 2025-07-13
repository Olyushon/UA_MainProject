using System.Collections.Generic;
using Meta.Features.Counters;
using Meta.Features.Wallet;

namespace Utilities.DataManagment
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyType, int> WalletData;
        public Dictionary<CounterType, int> CountersData;
    }
}
