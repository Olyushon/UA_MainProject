namespace Utilities.DataManagment.KeysStorage
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}