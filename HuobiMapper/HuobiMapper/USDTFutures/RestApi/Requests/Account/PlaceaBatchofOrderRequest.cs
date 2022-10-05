using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class PlaceaBatchofOrderRequest:KeyedRequestPayload
    {
    public PlaceaBatchofOrderRequest(long volume, string contractcode,string direction,
        int leverrate, string orderpricetype)
    {
        Direction = direction;
        Volume = volume;
        Contractcode = contractcode;
        Leverrate = leverrate;
        Orderpricetype = orderpricetype;
    }
    public string Contractcode { get; set; }
    public int ReduceOnly { get; set; }
    public long? ClientOrderId { get; set; }
    public decimal? Price { get; set; }
    public long? Volume { get; set; }
    public string Direction { get; set; }
    public string Offset { get; set; }
    public int Leverrate { get; set; } = 5;
    public string Orderpricetype { get; set; }
    public decimal? TpTriggerPrice { get; set; }
    public decimal? TpOrderPrice { get; set; }
    public string TpOrderPriceType { get; set; }
    public decimal? SlTriggerPrice { get; set; }
    public decimal? SlOrderPrice { get; set; }
    public string SlOrderPriceType { get; set; }
    internal override Dictionary<string, string> Properties
    {
        get
        {
            var def = new Dictionary<string, string>();
            def.AddStringIfNotEmptyOrWhiteSpace("direction", Direction);
            def.AddStringIfNotEmptyOrWhiteSpace("contract_code", Contractcode);
            def.AddStringIfNotEmptyOrWhiteSpace("offset", Offset);
            def.AddStringIfNotEmptyOrWhiteSpace("tp_order_price_type", TpOrderPriceType);
            def.AddStringIfNotEmptyOrWhiteSpace("sl_order_price_type", SlOrderPriceType);
            def.AddSimpleStruct("reduce_only", ReduceOnly);
            def.AddSimpleStruct("lever_rate", Leverrate);
            def.AddSimpleStructIfNotNull("price", Price);
            def.AddSimpleStructIfNotNull("tp_trigger_price", TpTriggerPrice);
            def.AddSimpleStructIfNotNull("tp_order_price", TpOrderPrice);
            def.AddSimpleStructIfNotNull("sl_trigger_price", SlTriggerPrice);
            def.AddSimpleStructIfNotNull("sl_order_price", SlOrderPrice);
            def.AddSimpleStructIfNotNull("volume", Volume);
            def.AddSimpleStructIfNotNull("client_order_id", ClientOrderId);
            return def;
        }
    }
    [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_cross_batchorder";
    internal override RequestMethod Method { get; } = RequestMethod.POST;
    }
}