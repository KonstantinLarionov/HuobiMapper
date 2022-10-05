using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceaBatchofOrders
{
    public class ErrorsPBO
    {
        [JsonConstructor]
        public ErrorsPBO(int index, int errcode, string errmsg)
        {
            Index = index;
            Errcode = errcode;
            Errmsg = errmsg;
        }
        [JsonProperty("index")]
        public int Index { get; set; }
        [JsonProperty("err_code")]
        public int Errcode { get; set; }
        [JsonProperty("err_msg")]
        public string Errmsg { get; set; }
    }
}