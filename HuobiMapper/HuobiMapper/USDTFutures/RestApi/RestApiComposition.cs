using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.PrivateStreams.PrivateResponses;
using HuobiMapper.USDTFutures.RestApi.Responses;

namespace HuobiMapper.USDTFutures.RestApi
{
    public class RestApiComposition
    {
        public CurrencyResponse HandLerGetCurrencyResponse(string json) =>
            json.Deserialize<CurrencyResponse>();

        public DataKlineResponse HandLerGetDataKlineResponse(string json) =>
            json.Deserialize<DataKlineResponse>();

        public PrivateResponses HandLerGetPrivateResponse(string json) =>
            json.Deserialize<PrivateResponses>();
    }

}