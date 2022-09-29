using Newtonsoft.Json;

namespace HuobiMapper.Extensions
{
    public static class JsonConvertExtensions
    {
        public static T Deserialize<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json);
        public static string Serialize(this object obj) =>
            JsonConvert.SerializeObject(obj);
    }
}