using Newtonsoft.Json;

namespace Utilities.DataManagment.Serializers
{
    public class JsonSerializer : IDataSerializer
    {
        public TData Deserialize<TData>(string serializedData)
        {
            return JsonConvert.DeserializeObject<TData>(serializedData);
        }

        public string Serialize<TData>(TData data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}