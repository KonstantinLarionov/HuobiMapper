using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.Place_a_Batch_of_Orders;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceaBatchofOrders
{
    public class DataPBO
    {
        [JsonConstructor]
        public DataPBO(List<ErrorsPBO> errorsPbo, List<SuccessPBO> successPbo)
        {
            ErrorSPBO = errorsPbo;
            SuccesSPBO = successPbo;
        }

        [JsonProperty("errors")] public List<ErrorsPBO> ErrorSPBO { get; set; }

        [JsonProperty("success")] public List<SuccessPBO> SuccesSPBO { get; set; }
    }
}