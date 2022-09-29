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
    }

}