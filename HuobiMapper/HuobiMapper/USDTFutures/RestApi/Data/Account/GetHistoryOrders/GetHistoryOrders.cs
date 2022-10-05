using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders
{
    public class GetHistoryOrders
    {   [JsonConstructor]
        public GetHistoryOrders(long queryId, long orderId, string contractCode, string symbol, int leverRate,
            string direction, string offset, decimal volume, decimal price, long createDate,
            long updateTime, string orderSource, string orderPriceType, int orderType,
            decimal marginFrozen, decimal profit, decimal tradeVolume, decimal tradeTurnover, decimal fee,
            decimal tradeAvgPrice, int status, string orderIdStr, string feeAsset, string liquidationType,
            string marginAsset, string marginMode, string marginAccount, int isTpsl, decimal realProfit,
            int reduceOnly)
        {
            QueryId = queryId;
            OrderId = orderId;
            ContractCode = contractCode;
            Symbol = symbol;
            LeverRate = leverRate;
            Direction = direction;
            Offset = offset;
            Volume = volume;
            Price = price;
            CreateDate = createDate;
            UpdateTime = updateTime;
            OrderSource = orderSource;
            OrderPriceType = orderPriceType;
            OrderType = orderType;
            MarginFrozen = marginFrozen;
            Profit = profit;
            TradeVolume = tradeVolume;
            TradeTurnover = tradeTurnover;
            Fee = fee;
            TradeAvgPrice = tradeAvgPrice;
            Status = status;
            OrderIdStr = orderIdStr;
            FeeAsset = feeAsset;
            LiquidationType = liquidationType;
            MarginAsset = marginAsset;
            MarginMode = marginMode;
            MarginAccount = marginAccount;
            IsTpsl = isTpsl;
            RealProfit = realProfit;
            ReduceOnly = reduceOnly;
        }

        [JsonProperty("query_id")]
        public long QueryId { get; set; }
        [JsonProperty("order_id")]
        public long OrderId { get; set; }
        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("lever_rate")]
        public int LeverRate { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("offset")]
        public string Offset { get; set; }
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("create_date")]
        public long CreateDate { get; set; }
        [JsonProperty("update_time")]
        public long UpdateTime { get; set; }
        [JsonProperty("order_source")]
        public string OrderSource { get; set; }
        [JsonProperty("order_price_type")]
        public string OrderPriceType { get; set; }
        [JsonProperty("order_type")]
        public int OrderType { get; set; }
        [JsonProperty("margin_frozen")]
        public decimal MarginFrozen { get; set; }
        [JsonProperty("profit")]
        public decimal Profit { get; set; }
        [JsonProperty("trade_volume")]
        public decimal TradeVolume { get; set; }
        [JsonProperty("trade_turnover")]
        public decimal TradeTurnover { get; set; }
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        [JsonProperty("trade_avg_price")]
        public decimal TradeAvgPrice { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("order_id_str")]
        public string OrderIdStr { get; set; }
        [JsonProperty("fee_asset")]
        public string FeeAsset { get; set; }
        [JsonProperty("liquidation_type")]
        public string LiquidationType { get; set; }
        [JsonProperty("margin_asset")]
        public string MarginAsset { get; set; }
        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }
        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }
        [JsonProperty("is_tpsl")]
        public int IsTpsl { get; set; }
        [JsonProperty("real_profit")]
        public decimal RealProfit { get; set; }
        [JsonProperty("reduce_only")]
        public int ReduceOnly { get; set; }
    }
}