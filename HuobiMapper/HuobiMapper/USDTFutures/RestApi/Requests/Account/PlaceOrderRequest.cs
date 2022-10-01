using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class PlaceOrderRequest : KeyedRequestPayload
    {
        public PlaceOrderRequest(string сontractCode, long volume,
            string direction, int leverRate, string orderPriceType)
        {
            ContractCode = сontractCode;
            Direction = direction;
            LeverRate = leverRate;
            Volume = volume;
            OrderPriceType = orderPriceType;
        }
        public string ContractCode { get; set; }
        public string Direction{ get; set; }
        public int LeverRate { get; set; } = 5;
        public long Volume { get; set; } = 1;
        public string OrderPriceType{ get; set; }
        public string Offset{ get; set; }
        public decimal Price{ get; set; }
        public decimal TpTriggerPrice{ get; set; }
        public decimal TpOrderPrice{ get; set; }
        public string TpOrderPriceType{ get; set; }
        public decimal SlTriggerPrice{ get; set; }
        public decimal SlOrderPrice{ get; set; }
        public string sl_order_price_type{ get; set; }

        internal override Dictionary<string, string> Properties
        {
            get
            {
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code",ContractCode);
                def.AddStringIfNotEmptyOrWhiteSpace("direction",Direction);
                def.AddStringIfNotEmptyOrWhiteSpace("order_price_type",OrderPriceType);
                def.AddStringIfNotEmptyOrWhiteSpace("offset",Offset);
                def.AddStringIfNotEmptyOrWhiteSpace("tp_order_price_type",TpOrderPriceType);
                def.AddStringIfNotEmptyOrWhiteSpace("sl_order_price_type",sl_order_price_type);
                def.AddSimpleStruct("lever_rate",LeverRate);
                def.AddSimpleStruct("volume",Volume);
                def.AddSimpleStruct("price",Price);
                def.AddSimpleStruct("tp_trigger_price",TpTriggerPrice);
                def.AddSimpleStruct("tp_order_price",TpOrderPrice);
                def.AddSimpleStruct("sl_trigger_price",SlTriggerPrice);
                def.AddSimpleStruct("sl_order_price",SlOrderPrice);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_order";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
    }
}