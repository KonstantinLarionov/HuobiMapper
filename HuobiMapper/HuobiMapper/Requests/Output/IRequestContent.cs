using System.Collections.Generic;

namespace HuobiMapper.Requests.Output
{
    public interface IRequestContent
    {
        RequestMethod Method { get; }

        string Query { get; }

        /// <summary>
        /// Authorized requests only; null otherwise
        /// </summary>
        IReadOnlyDictionary<string, string> Headers { get; }

        object Body { get; }
    }
}