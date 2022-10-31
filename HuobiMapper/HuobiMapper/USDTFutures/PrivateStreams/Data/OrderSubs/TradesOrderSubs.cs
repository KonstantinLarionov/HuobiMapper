using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Data.OrderSubs
{
    public class TradesOrderSubs
    {
        [JsonProperty("trade_id")]
        public int TradeId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("trade_volume")]
        public int TradeVolume { get; set; }

        [JsonProperty("trade_price")]
        public double TradePrice { get; set; }

        [JsonProperty("trade_fee")]
        public double TradeFee { get; set; }

        [JsonProperty("fee_asset")]
        public string FeeAsset { get; set; }

        [JsonProperty("trade_turnover")]
        public double TradeTurnover { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("real_profit")]
        public int RealProfit { get; set; }

        [JsonProperty("profit")]
        public int Profit { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}