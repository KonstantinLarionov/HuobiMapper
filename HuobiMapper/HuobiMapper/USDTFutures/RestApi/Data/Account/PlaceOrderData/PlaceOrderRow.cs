using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData
{
    public class PlaceOrderRow
    {
        [JsonConstructor]
        public PlaceOrderRow(string сontractCode, int reduceOnly, long clientOrderId, decimal price, long volume,
                string direction, string offset, int leverRate, string orderPriceType,decimal tpTriggerPrice, decimal tpOrderPrice,
                string tpOrderPriceType, decimal slTriggerPrice, decimal slOrderPrice,
                string slOrderPriceType)
           {
               ContractCode = сontractCode;
               ReduceOnly = reduceOnly;
               ClientOrderId = clientOrderId;
               Price = price;
               Volume = volume;
               Direction = direction;
               Offset = offset;
               LeverRate = leverRate;
               OrderPriceType = orderPriceType;
               TpTriggerPrice = tpTriggerPrice;
               TpOrderPrice = tpOrderPrice;
               TpOrderPriceType = tpOrderPriceType;
               SlTriggerPrice = slTriggerPrice;
               SlOrderPrice = slOrderPrice;
               SlOrderPriceType = slOrderPriceType;
           }
           [JsonProperty("contract_code")]
           public string ContractCode { get; set; }
           [JsonProperty("reduce_only")]
           public int ReduceOnly { get; set; }
           [JsonProperty("client_order_id")]
           public long ClientOrderId { get; set; }
           [JsonProperty("price")]
           public decimal Price { get; set; }
           [JsonProperty("volume")]
           public long Volume { get; set; }
           [JsonProperty("direction")]
           public string Direction { get; set; }
           [JsonProperty("offset")]
           public string Offset { get; set; }
           [JsonProperty("lever_rate")]
           public int LeverRate { get; set; }
           [JsonProperty("order_price_type")]
           public string OrderPriceType { get; set; }
           [JsonProperty("tp_trigger_price")]
           public decimal TpTriggerPrice { get; set; }
           [JsonProperty("tp_order_price")]
           public decimal TpOrderPrice { get; set; }
           [JsonProperty("tp_order_price_type")]
           public string TpOrderPriceType { get; set; }
           [JsonProperty("sl_trigger_price")]
           public decimal SlTriggerPrice { get; set; }
           [JsonProperty("sl_order_price")]
           public decimal SlOrderPrice { get; set; }
           [JsonProperty("sl_order_price_type")]
           public string SlOrderPriceType { get; set; }


    }
}