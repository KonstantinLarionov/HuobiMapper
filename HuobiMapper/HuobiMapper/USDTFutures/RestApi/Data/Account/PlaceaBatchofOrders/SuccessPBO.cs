using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.Place_a_Batch_of_Orders
{
    public class SuccessPBO
    {   
        [JsonConstructor]
        public SuccessPBO(long orderid, long clientorderid, int index, string orderidstr)
        {
            Orderid = orderid;
            Clientorderid = clientorderid;
            Index = index;
            Orderidstr = orderidstr;
        }
        [JsonProperty("order_id")]
        public long Orderid { get; set; }
        [JsonProperty("client_order_id")]
        public long Clientorderid { get;set; }
        [JsonProperty("index")]
        public int Index { get; set; }
        [JsonProperty("order_id_str")]
        public string Orderidstr { get; set; }
    }
}