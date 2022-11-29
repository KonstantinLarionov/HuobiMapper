using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.TradeHistory
{
    public class TradeData
    {
        [JsonProperty("query_id")]
        public int QueryId { get; set; }

        [JsonProperty("contract_type")]
        public string ContractType { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("business_type")]
        public string BusinessType { get; set; }

        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
        public DirectionEnum DirectionType {
            get
            {
                return Direction.ToEnum<DirectionEnum>();
            }
        }

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("trade_volume")]
        public decimal TradeVolume { get; set; }

        [JsonProperty("trade_price")]
        public double TradePrice { get; set; }

        [JsonProperty("trade_turnover")]
        public double TradeTurnover { get; set; }

        [JsonProperty("trade_fee")]
        public double TradeFee { get; set; }

        [JsonProperty("offset_profitloss")]
        public double OffsetProfitloss { get; set; }

        [JsonProperty("create_date")]
        public long CreateDate { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("order_source")]
        public string OrderSource { get; set; }

        [JsonProperty("order_id_str")]
        public string OrderIdStr { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fee_asset")]
        public string FeeAsset { get; set; }

        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }

        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }

        [JsonProperty("real_profit")]
        public double RealProfit { get; set; }

        [JsonProperty("reduce_only")]
        public int ReduceOnly { get; set; }
    }
}