using System;
using System.Collections;

namespace Utilities.DataManagment.DataProviders
{
    public abstract class DataProvider<TData> where TData : ISaveData
    {
        private readonly ISaveLoadService _saveLoadSerivce;

        private TData _data;

        protected DataProvider(ISaveLoadService saveLoadSerivce)
        {
            _saveLoadSerivce = saveLoadSerivce;
        }

        public IEnumerator Load()
        {
            yield return _saveLoadSerivce.Load<TData>(loadedData => _data = loadedData);
        }

        public IEnumerator Save()
        {
            yield return _saveLoadSerivce.Save(_data);
        }

        public IEnumerator Exists(Action<bool> onExistsResult)
        {
            yield return _saveLoadSerivce.Exists<TData>(result => onExistsResult?.Invoke(result));
        }

        public void Reset()
        {
            _data = GetOriginData();
        }

        protected abstract TData GetOriginData();
    }
}