using HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders;
using HuobiMapper.USDTFutures.RestApi.Extensions;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition
{
    public class Orders
    {   [JsonConstructor]
        public Orders(string symbol, string contractCode, decimal volume, decimal price, string orderPriceType,
            int orderType, string direction, string offset, int leverRate, long orderId, long? clientOrderId, long createdAt,
            decimal tradeVolume, decimal tradeTurnover, decimal fee, decimal? tradeAvgPrice, decimal marginFrozen, decimal profit,
            int status, string orderSource, string orderIdStr, string feeAsset, string liquidationType, long? canceledAt, string marginAsset,
            string marginMode, string marginAccount, int isTpsl, long updateTime, decimal realProfit, int reduceOnly)
        {
            Symbol = symbol;
            ContractCode = contractCode;
            Volume = volume;
            Price = price;
            OrderPriceType = orderPriceType;
            OrderPriceTypeEnum = OrderPriceType.ToEnum<OrderPriceTypeEnum>();
            OrderType = orderType;
            Direction = direction;
            DirectionEnum = Direction.ToEnum<DirectionEnum>();
            Offset = offset;
            LeverRate = leverRate;
            OrderId = orderId;
            ClientOrderId = clientOrderId;
            CreatedAt = createdAt;
            TradeVolume = tradeVolume;
            TradeTurnover = tradeTurnover;
            Fee = fee;
            TradeAvgPrice = tradeAvgPrice;
            MarginFrozen = marginFrozen;
            Profit = profit;
            Status = status;
            StatusEnum = (OrderStatusEnum)Status;
            OrderSource = orderSource;
            OrderIdStr = orderIdStr;
            FeeAsset = feeAsset;
            LiquidationType = liquidationType;
            CanceledAt = canceledAt;
            MarginAsset = marginAsset;
            MarginMode = marginMode;
            MarginAccount = marginAccount;
            IsTpsl = isTpsl;
            UpdateTime = updateTime;
            RealProfit = realProfit;
            ReduceOnly = reduceOnly;
        }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("order_price_type")]
        public string OrderPriceType { get; set; }

        public OrderPriceTypeEnum OrderPriceTypeEnum { get; set; }

        [JsonProperty("order_type")]
        public int OrderType { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }

        public DirectionEnum DirectionEnum { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }
        [JsonProperty("lever_rate")]
        public int LeverRate { get; set; }
        [JsonProperty("order_id")]
        public long OrderId { get; set; }
        [JsonProperty("client_order_id")]
        public long? ClientOrderId { get; set; }
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
        [JsonProperty("trade_volume")]
        public decimal TradeVolume { get; set; }
        [JsonProperty("trade_turnover")]
        public decimal TradeTurnover { get; set; }
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        [JsonProperty("trade_avg_price")]
        public decimal? TradeAvgPrice { get; set; }
        [JsonProperty("margin_frozen")]
        public decimal MarginFrozen { get; set; }
        [JsonProperty("profit")]
        public decimal Profit { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }

        public OrderStatusEnum StatusEnum { get; set; }

        [JsonProperty("order_source")]
        public string OrderSource { get; set; }
        [JsonProperty("order_id_str")]
        public string OrderIdStr { get; set; }
        [JsonProperty("fee_asset")]
        public string FeeAsset { get; set; }
        [JsonProperty("liquidation_type")]
        public string LiquidationType { get; set; }
        [JsonProperty("canceled_at")]
        public long? CanceledAt { get; set; }
        [JsonProperty("margin_asset")]
        public string MarginAsset { get; set; }
        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }
        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }
        [JsonProperty("is_tpsl")]
        public int IsTpsl { get; set; }
        [JsonProperty("update_time")]
        public long UpdateTime { get; set; }
        [JsonProperty("real_profit")]
        public decimal RealProfit { get; set; }
        [JsonProperty("reduce_only")]
        public int ReduceOnly { get; set; }
    }
}