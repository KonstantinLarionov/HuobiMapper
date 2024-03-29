﻿using System.Collections.Generic;
using Huobi.SDK.Core.WSBase.PrivateStreams.Data.OrderSubs;
using HuobiMapper.USDTFutures.RestApi.Extensions;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Event
{
    public class OrdersEvent
    {
        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

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

        public OrderPriceTypeEnum OrderPriceTypeEnum {
            get
            {
                return OrderPriceType.ToEnum<OrderPriceTypeEnum>();
            }
        }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        public DirectionEnum DirectionEnum {
            get
            {
                return Direction.ToEnum<DirectionEnum>();
            }
        }

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        public OrderStatusEnum StatusEnum
        {
            get
            {
                return (OrderStatusEnum)Status;
            }
        }

        [JsonProperty("lever_rate")]
        public int LeverRate { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("order_id_str")]
        public string OrderIdStr { get; set; }

        [JsonProperty("client_order_id")]
        public string ClientOrderId { get; set; }

        [JsonProperty("order_source")]
        public string OrderSource { get; set; }

        [JsonProperty("order_type")]
        public int OrderType { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("trade_volume")]
        public decimal TradeVolume { get; set; }

        [JsonProperty("trade_turnover")]
        public decimal TradeTurnover { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("liquidation_type")]
        public string LiquidationType { get; set; }

        [JsonProperty("trade_avg_price")]
        public decimal TradeAvgPrice { get; set; }

        [JsonProperty("margin_asset")]
        public string MarginAsset { get; set; }

        [JsonProperty("margin_frozen")]
        public decimal MarginFrozen { get; set; }

        [JsonProperty("profit")]
        public decimal Profit { get; set; }

        [JsonProperty("canceled_at")]
        public long CanceledAt { get; set; }

        [JsonProperty("fee_asset")]
        public string FeeAsset { get; set; }

        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }

        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }

        [JsonProperty("is_tpsl")]
        public decimal IsTpsl { get; set; }

        [JsonProperty("real_profit")]
        public decimal RealProfit { get; set; }

        [JsonProperty("reduce_only")]
        public decimal ReduceOnly { get; set; }

        [JsonProperty("trade")]
        public List<TradesOrderSubs> Trade { get; set; }
    }
}