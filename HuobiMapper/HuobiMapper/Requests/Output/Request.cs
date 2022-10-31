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
        
        public virtual string Query => _requestPayload.EndPoint;

        public virtual string RawProperty
        {
            get { 
                if(InternalProperties.Count != 0) return GenerateParametersString(InternalProperties);
                return string.Empty;
            }
        }
        public RequestMethod Method => _requestPayload.Method;

        public virtual IReadOnlyDictionary<string, string> Headers => null;

        public object Body => _requestPayload.Body;
        protected virtual string GenerateParametersString( [NotNull] IDictionary<string, string> properties) =>
            string.Join("&", properties.Select(a => $"{System.Net.WebUtility.UrlEncode(a.Key).Replace("%25", "%")}={System.Net.WebUtility.UrlEncode(a.Value).Replace("%25", "%")}"));
    }
}