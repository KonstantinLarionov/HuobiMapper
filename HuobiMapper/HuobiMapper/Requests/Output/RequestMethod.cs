// ReSharper disable InconsistentNaming

using System.Runtime.Serialization;
using System.Security;

namespace HuobiMapper.Requests.Output
{
    public enum RequestMethod
    {
        [EnumMember(Value = "GET")]
        GET,
        [EnumMember(Value = "POST")]
        POST,
        PUT,
        DELETE
    }
}