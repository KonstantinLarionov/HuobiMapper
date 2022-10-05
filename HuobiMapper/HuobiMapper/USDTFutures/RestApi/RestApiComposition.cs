using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Responses.Account;
using HuobiMapper.USDTFutures.RestApi.Responses.Market;

namespace HuobiMapper.USDTFutures.RestApi
{
    public class RestApiComposition
    {
        public CurrencyResponse HandLerGetCurrencyResponse(string json) =>
            json.Deserialize<CurrencyResponse>();

        public DataKlineResponse HandLerGetDataKlineResponse(string json) =>
            json.Deserialize<DataKlineResponse>();

        public AccountResponses HandLerGetPrivateResponse(string json) =>
            json.Deserialize<AccountResponses>();

        public CancelanOrderResponses HadlerGetCancelanOrderResponses(string json) =>
            json.Deserialize<CancelanOrderResponses>();
        
        public CurrentUnfilledOrderAcquisitionResponses HandLerGetCurrentUnfilledOrderAcquisitionResponses(string json) =>
            json.Deserialize<CurrentUnfilledOrderAcquisitionResponses>();
        
        public GetHistoryOrdersResponses HandLerGetGetHistoryOrdersResponses(string json) =>
            json.Deserialize<GetHistoryOrdersResponses>();
        
        public PlaceaBatchofOrderResponses HandLerGetPlaceaBatchofOrderResponses(string json) =>
            json.Deserialize<PlaceaBatchofOrderResponses>();
        
        public PlaceOrderResponses HandLerGetPlaceOrderResponses(string json) =>
            json.Deserialize<PlaceOrderResponses>();
        
        public QueryUserSAccountInformationResponses HandLerGetQueryUserSAccountInformationResponses(string json) =>
            json.Deserialize<QueryUserSAccountInformationResponses>();
        
    }

}