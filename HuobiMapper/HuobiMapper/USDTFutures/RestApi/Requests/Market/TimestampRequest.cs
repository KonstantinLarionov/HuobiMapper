using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Market
{
    public class TimestampRequest: RequestPayload
    {
        internal override string EndPoint { get; } = "/api/v1/timestamp";
        internal override RequestMethod Method { get; } = RequestMethod.GET;
    }
}