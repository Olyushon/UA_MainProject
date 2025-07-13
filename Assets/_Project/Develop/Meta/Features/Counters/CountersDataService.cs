using System.Collections.Generic;
using Utilities.DataManagment;
using Utilities.DataManagment.DataProviders;
using Utilities.Reactive;

namespace Meta.Features.Counters
{
    public class CountersDataService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<CounterType, ReactiveVariable<int>> _counters;

        public CountersDataService(
            Dictionary<CounterType, ReactiveVariable<int>> counters, 
            PlayerDataProvider playerDataProvider)
        {
            _counters = new Dictionary<CounterType, ReactiveVariable<int>>(counters);

            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyVariable<int> GetCount(CounterType type) => _counters[type];

        public void IncreaseCounter(CounterType type)
        {
            _counters[type].Value++;
        }

        public void ResetCounters()
        {
            foreach (KeyValuePair<CounterType, ReactiveVariable<int>> counter in _counters)
                counter.Value.Value = 0;
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<CounterType, int> counter in data.CountersData)
            {
                if (_counters.ContainsKey(counter.Key))
                    _counters[counter.Key].Value = counter.Value;
                else
                    _counters.Add(counter.Key, new ReactiveVariable<int>(counter.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<CounterType, ReactiveVariable<int>> counter in _counters)
            {
                if (data.CountersData.ContainsKey(counter.Key))
                    data.CountersData[counter.Key] = counter.Value.Value;
                else
                    data.CountersData.Add(counter.Key, counter.Value.Value);
            }
        }
    }
}
