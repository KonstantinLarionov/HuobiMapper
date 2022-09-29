using System;
using System.Collections.Generic;
using System.Linq;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.Requests.Output
{
    internal class Request : IRequestContent
    {
        private readonly RequestPayload _requestPayload;
        private readonly string _apiKey;
        public Request([NotNull] RequestPayload requestPayload,[CanBeNull]  string apiKey)
        {
            _requestPayload = requestPayload ?? throw new ArgumentNullException(nameof(requestPayload));
            _apiKey = apiKey;
        }

        public virtual string Query {
            get {
                if (_requestPayload.Properties is null || _requestPayload.Properties.Count == 0)
                {
                    return _requestPayload.EndPoint;
                }
                else
                {
                    return $"{_requestPayload.EndPoint}?{GenerateParametersString(_requestPayload.Properties)}";
                }

            }
        }
        public RequestMethod Method => _requestPayload.Method;

        public virtual IReadOnlyDictionary<string, string> Headers => null;

        public object Body => _requestPayload.Body;
        protected virtual string GenerateParametersString( [NotNull] IDictionary<string, string> properties) =>
            string.Join("&", properties.Select(a => $"{a.Key}={a.Value}"));
    }
}