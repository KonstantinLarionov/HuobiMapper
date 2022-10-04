using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.Place_a_Batch_of_Orders
{
    public class PlaceaBAtchofOrdersRow
    {
        [JsonConstructor]
        public PlaceaBAtchofOrdersRow(string contractcode, string direction, string offset,
            decimal price, int leverrate, long volume, string orderpricetype,
            decimal tptriggerprice, decimal tporderprice, string tporderpricetype,
            decimal sltriggerprice, decimal slorderprice, string slorderpricetype)
        {
            Contractcode = contractcode;
            Direction = direction;
            Offset = offset;
            Price = price;
            Leverrate = leverrate;
            Volume = volume;
            Orderpricetype = orderpricetype;
            Tptriggerprice = tptriggerprice;
            Tporderprice = tporderprice;
            Tporderpricetype = tporderpricetype;
            Sltriggerprice = sltriggerprice;
            Slorderprice = slorderprice;
            Slorderpricetype = slorderpricetype;
        }
        [JsonProperty("contract_code")]
        public string Contractcode { get; set; }
        
        [JsonProperty("direction")]
        public string Direction { get; set; }
         
        [JsonProperty("offset")]
        public string Offset { get; set; }
         
        [JsonProperty("price")]
        public decimal Price { get; set; }
         
        [JsonProperty("lever_rate")]
        public int Leverrate { get; set; }
         
        [JsonProperty("volume")]
        public long Volume { get; set; }
         
        [JsonProperty("order_price_type")]
        public string Orderpricetype { get; set; }
         
        [JsonProperty("tp_trigger_price")]
        public decimal Tptriggerprice { get; set; }
         
        [JsonProperty("tp_order_price")]
        public decimal Tporderprice { get; set; }
         
        [JsonProperty("tp_order_price_type")]
        public string Tporderpricetype { get; set; }
         
        [JsonProperty("sl_trigger_price")]
        public decimal Sltriggerprice { get; set; }
         
        [JsonProperty("sl_order_price")]
        public decimal Slorderprice { get; set; }
         
        [JsonProperty("sl_order_price_type")]
        public string Slorderpricetype { get; set; }
        
    }
}