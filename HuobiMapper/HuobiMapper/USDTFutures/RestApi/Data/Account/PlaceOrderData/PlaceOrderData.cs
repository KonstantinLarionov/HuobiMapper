using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData
{
    public class PlaceOrderData
    {
        [JsonConstructor]
        
           public PlaceOrderData(string contract_code, int reduce_only, long client_order_id, decimal price, long volume,
                string direction, string offset, int lever_rate, string order_price_type,decimal tp_trigger_price, decimal tp_order_price,
                string tp_order_price_type, decimal sl_trigger_price, decimal sl_order_price,
                string sl_order_price_type)
           {
               ContractCode = contract_code;
               ReduceOnly = reduce_only;
               ClientOrderId = client_order_id;
               Price = price;
               Volume = volume;
               Direction = direction;
               Offset = offset;
               Lever_rate = lever_rate;
           }
        
    }
}