using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.PrivateStreams.Events;

namespace HuobiMapper.USDTFutures.PrivateStreams
{
    public class ContractsPrivateStreams
    {
        
        public BaseEvent HandlerGetBaseEvent(string json) => 
            json.Deserialize<BaseEvent>();
        public AOPEvent HandlerGetAOPEvent(string json) => 
            json.Deserialize<AOPEvent>();
    }
}