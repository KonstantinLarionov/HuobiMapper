﻿using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class PlaceOrderRequest : KeyedRequestPayload
    {
        public PlaceOrderRequest(string сontractCode, long volume,
            DirectionEnum direction, int leverRate, OrderPriceTypeEnum orderPriceType)
        {
            ContractCode = сontractCode;
            Direction = direction;
            LeverRate = leverRate;
            Volume = volume;
            OrderPriceType = orderPriceType;
        }
        public string ContractCode { get; set; }
        public DirectionEnum Direction{ get; set; }
        public int LeverRate { get; set; }
        public long Volume { get; set; }
        public OrderPriceTypeEnum OrderPriceType{ get; set; }
        public string Offset{ get; set; }
        public decimal? Price{ get; set; }
        public string ChannelCode { get; set; }
        public decimal? TpTriggerPrice{ get; set; }
        public decimal? TpOrderPrice{ get; set; }
        public string TpOrderPriceType{ get; set; }
        public decimal? SlTriggerPrice{ get; set; }
        public decimal? SlOrderPrice{ get; set; }
        public string sl_order_price_type{ get; set; }
        public override object Body {
            get
            {
                return Properties.FromDictToAnonymousObj();
            }
        }

        public override Dictionary<string, string> Properties
        {
            get
            {
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code",ContractCode);
                def.AddEnum("direction",Direction);
                def.AddEnum("order_price_type",OrderPriceType);
                def.AddStringIfNotEmptyOrWhiteSpace("offset",Offset);
                def.AddStringIfNotEmptyOrWhiteSpace("tp_order_price_type",TpOrderPriceType);
                def.AddStringIfNotEmptyOrWhiteSpace("sl_order_price_type",sl_order_price_type);
                def.AddSimpleStruct("lever_rate",LeverRate);
                def.AddSimpleStruct("volume",Volume);
                def.AddDecimalIfNotNull("price",Price);
                def.AddSimpleStructIfNotNull("tp_trigger_price",TpTriggerPrice);
                def.AddSimpleStructIfNotNull("tp_order_price",TpOrderPrice);
                def.AddSimpleStructIfNotNull("sl_trigger_price",SlTriggerPrice);
                def.AddSimpleStructIfNotNull("sl_order_price",SlOrderPrice);
                def.AddStringIfNotEmptyOrWhiteSpace("channel_code", ChannelCode);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_order";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
        
      
    }
}