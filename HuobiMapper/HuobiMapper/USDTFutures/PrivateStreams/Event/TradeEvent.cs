using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Event
{
    public class TradeEvent
    {
        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("order_id_str")]
        public string OrderIdStr { get; set; }

        [JsonProperty("client_order_id")]
        public object ClientOrderId { get; set; }

        [JsonProperty("order_type")]
        public int OrderType { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("trade")]
        public List<Huobi.SDK.Core.WSBase.PrivateStreams.Data.TradeData> Trade { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }

        [JsonProperty("trade_volume")]
        public int TradeVolume { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("lever_rate")]
        public int LeverRate { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("order_source")]
        public string OrderSource { get; set; }

        [JsonProperty("order_price_type")]
        public string OrderPriceType { get; set; }

        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }

        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }

        [JsonProperty("is_tpsl")]
        public int IsTpsl { get; set; }

        [JsonProperty("reduce_only")]
        public int ReduceOnly { get; set; }
    }
}