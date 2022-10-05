using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.CancealanOrder
{
    public class CancelanOrderErrors
    {
        [JsonConstructor]
        public CancelanOrderErrors(string orderid, int errcode, string errmsg)
        {
            Orderid = orderid;
            Errcode = errcode;
            Errmsg = errmsg;
        }
        [JsonProperty("order_id")]
        public string Orderid { get; set; }
        [JsonProperty("err_code")]
        public int Errcode { get; set; }
        [JsonProperty("err_msg")]
        public string Errmsg { get; set; }
    }
}