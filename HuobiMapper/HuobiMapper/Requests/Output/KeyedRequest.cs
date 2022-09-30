using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.Requests.Output
{ 
    internal class KeyedRequest : Request
    {
        public KeyedRequest([NotNull] RequestPayload requestPayload, [NotNull] string apiKey,
            [NotNull] string apiSecret, string host, string signmethod, string signversion, [NotNull] DateTime timestamp)
            : base(requestPayload, apiKey)
        {
            var props = new Dictionary<string, string>();
            var props2 = new Dictionary<string, string>();
            props.Add("AccessKeyId", apiKey);
            props.Add("SignatureMethod", signmethod);
            props.Add("SignatureVersion", signversion);
            props.Add("Timestamp", timestamp.ToString("s"));

            foreach (var VARIABLE in props)
            {
                props2.Add(VARIABLE.Key, VARIABLE.Value);
            }
            
            foreach (var VARIABLE in requestPayload.Properties)
            {
                props2.Add(VARIABLE.Key, VARIABLE.Value);
            }
            
            var sign = this.CreateSignature(
                this.BuilderSign(requestPayload.Method, host, requestPayload.EndPoint, props2),
                apiSecret);
            props.Add("Signature", sign);
            
            this.AppendPropsKeyedRequest(props);
        }
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private string BuilderSign(RequestMethod method, string host, string clear_query,
            Dictionary<string, string> properties)
        {
            var method_str = method.GetEnumMemberAttributeValue();
            var param_str = GenerateParametersString(properties);
            return $"{method_str}\n{host}\n{clear_query}\n{param_str}";
        }

        public string CreateSignature(string message, string secret)
        {
            var signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return  Convert.ToBase64String(signatureBytes);
        }

        private byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }   
        }
    }
}
 
