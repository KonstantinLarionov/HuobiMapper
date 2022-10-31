using System.Collections.Generic;
using System.ComponentModel;

namespace HuobiMapper.Requests.Payload
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class KeyedRequestPayload : RequestPayload
    {

        public int? ActualityWindow { get; set; }

        public long Timestamp { get; set; }
        public override object Body { get; }

        public override Dictionary<string, string> Properties
        {
            get
            {
                var result = new Dictionary<string, string>();

                return result;
            }
        }
    }
}