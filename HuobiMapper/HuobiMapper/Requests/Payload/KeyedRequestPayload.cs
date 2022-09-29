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
        internal override object Body { get; }

        internal override Dictionary<string, string> Properties
        {
            get
            {
                var result = new Dictionary<string, string>();

                return result;
            }
        }
    }
}