using Huobi.SDK.Core.WSBase.PrivateStreams.Data;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Event
{
    public class BaseEvent
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }

        public EventType EventType {
            get
            {
                if (Topic != null && Topic.Contains("positions"))
                    return EventType.Position;
                if (Topic != null && Topic.Contains("orders"))
                    return EventType.Orders;
                return EventType.None;
            }
        }
    }
}