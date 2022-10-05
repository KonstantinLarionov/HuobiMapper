using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.QueryUser_sAccountInformation
{
    public class QueryUserSAccountInformation
    {   [JsonConstructor]
        public QueryUserSAccountInformation(string symbol, string contractCode, decimal volume, decimal available,
            decimal frozen, decimal costOpen, decimal costHold, decimal profitUnreal, decimal profitRate, int leverRate,
            decimal positionMargin, string direction, decimal profit, decimal lastPrice, string marginAsset, string marginMode,
            string marginAccount, string positionMode)
        {
            Symbol = symbol;
            ContractCode = contractCode;
            Volume = volume;
            Available = available;
            Frozen = frozen;
            CostOpen = costOpen;
            CostHold = costHold;
            ProfitUnreal = profitUnreal;
            ProfitRate = profitRate;
            LeverRate = leverRate;
            PositionMargin = positionMargin;
            Direction = direction;
            Profit = profit;
            LastPrice = lastPrice;
            MarginAsset = marginAsset;
            MarginMode = marginMode;
            MarginAccount = marginAccount;
            PositionMode = positionMode;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
        [JsonProperty("available")]
        public decimal Available { get; set; }
        [JsonProperty("frozen")]
        public decimal Frozen { get; set; }
        [JsonProperty("cost_open")]
        public decimal CostOpen { get; set; }
        [JsonProperty("cost_hold")]
        public decimal CostHold { get; set; }
        [JsonProperty("profit_unreal")]
        public decimal ProfitUnreal { get; set; }
        [JsonProperty("profit_rate")]
        public decimal ProfitRate { get; set; }
        [JsonProperty("lever_rate")]
        public int LeverRate { get; set; }
        [JsonProperty("position_margin")]
        public decimal PositionMargin { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("profit")]
        public decimal Profit { get; set; }
        [JsonProperty("last_price")]
        public decimal LastPrice { get; set; }
        [JsonProperty("margin_asset")]
        public string MarginAsset { get; set; }
        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }
        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }
        [JsonProperty("position_mode")]
        public string PositionMode { get; set; }
    }
}