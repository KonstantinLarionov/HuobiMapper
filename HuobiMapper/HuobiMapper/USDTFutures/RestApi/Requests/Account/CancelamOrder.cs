using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class CancelamOrder
    {
        [JsonConstructor]
        public CancelamOrder(string orderid, string clientorderid, string contractcode)
    }
}