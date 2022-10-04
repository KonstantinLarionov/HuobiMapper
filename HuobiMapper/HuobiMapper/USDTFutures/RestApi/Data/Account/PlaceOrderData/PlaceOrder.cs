using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData
{
    public class PlaceOrder
    
    {
        [JsonConstructor]
        public PlaceOrder(long orderId, long clientOrderId, string orderIdStr)
        {
            OrderId = orderId;
            ClientOrderId = clientOrderId;
            OrderIdStr = orderIdStr;
        }
        [JsonProperty("order_id")]
        public long OrderId { get; set; }
        [JsonProperty("client_order_id")]
        public long ClientOrderId { get; set; }
        [JsonProperty("order_id_str")]
        public string OrderIdStr { get; set; }
    }
}