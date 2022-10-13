using System;
using System.Collections.Generic;
using System.Linq;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.Requests.Output
{
    internal class Request : IRequestContent
    {
        private RequestPayload _requestPayload;
        private Dictionary<string, string> InternalProperties;
        private readonly string _apiKey;
        public Request([NotNull] RequestPayload requestPayload,[CanBeNull]  string apiKey)
        {
            _requestPayload = requestPayload ?? throw new ArgumentNullException(nameof(requestPayload));
            InternalProperties = _requestPayload.Properties ?? new Dictionary<string, string>();
            _apiKey = apiKey;
        }

        public void AppendPropsKeyedRequest(Dictionary<string, string> prop)
        {
            foreach (var VARIABLE in prop)
                this.InternalProperties.Add(System.Net.WebUtility.UrlEncode(VARIABLE.Key).Replace("%25", "%"), System.Net.WebUtility.UrlEncode(VARIABLE.Value).Replace("%25", "%"));

            this.InternalProperties.OrderBy(x => x.Key, StringComparer.Ordinal);
        }

        private string buffer = string.Empty;
        public virtual string Query
        {
            get {
                if (!string.IsNullOrEmpty(buffer))
                {
                    return buffer;
                }

                // if (InternalProperties is null || InternalProperties.Count == 0)
                // {
                    return _requestPayload.EndPoint;
                // }
                // else
                // {
                //     return $"{_requestPayload.EndPoint}?{GenerateParametersString(InternalProperties)}";
                // }
            }
            set
            {
                buffer = value;
            }
        }
        public RequestMethod Method => _requestPayload.Method;

        public virtual IReadOnlyDictionary<string, string> Headers => null;

        public object Body => _requestPayload.Body;
        protected virtual string GenerateParametersString( [NotNull] IDictionary<string, string> properties) =>
            string.Join("&", properties.Select(a => $"{System.Net.WebUtility.UrlEncode(a.Key).Replace("%25", "%")}={System.Net.WebUtility.UrlEncode(a.Value).Replace("%25", "%")}"));
    }
}