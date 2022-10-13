using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Huobi.SDK.Core.RequestBuilder;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.Requests.Output
{ 
    internal class KeyedRequest : Request
    {
        public KeyedRequest([NotNull] RequestPayload requestPayload, [NotNull] string apiKey,
            [NotNull] string apiSecret, string host, string signmethod, string signversion, [NotNull] long timestamp)
            : base(requestPayload, apiKey)
        {

            var builder = new PrivateUrlBuilder(apiKey, apiSecret, host);
            
            string method = requestPayload.Method.GetEnumMemberAttributeValue();
            string endpoint = requestPayload.EndPoint;

            var timelong = timestamp;
            var mytimelong = DateTime.UtcNow.ToUnixTimeMilliseconds();
            var datetime = timestamp.ToDateTimeFromUnixTimeMilliseconds();
            string result = builder.Build(method, endpoint, datetime);
            this.Query = result;
            // var props = new Dictionary<string, string>();
            // var props2 = new Dictionary<string, string>();
            // props.Add("AccessKeyId", apiKey);
            // props.Add("SignatureMethod", signmethod);
            // props.Add("SignatureVersion", signversion);
            // props.Add("Timestamp", DateTime.UtcNow.ToString("s"));
            // // props.Add("Timestamp", timestamp.ToString("s"));
            //
            // foreach (var VARIABLE in props)
            // {
            //     props2.Add(VARIABLE.Key, VARIABLE.Value);
            // }
            //
            // foreach (var VARIABLE in requestPayload.Properties)
            // {
            //     props2.Add(VARIABLE.Key, VARIABLE.Value);
            // }
            //
            // var sign_sdk = new Signer(apiSecret);
            // string method = requestPayload.Method.GetEnumMemberAttributeValue();
            // string endpoint = requestPayload.EndPoint;
            // string param = GenerateParametersString(props2);
            //
            // var sign_fromsdk = sign_sdk.Sign(method, host, endpoint,param);
            // var string_builders = this.BuilderSign(requestPayload.Method, host, requestPayload.EndPoint, props2);
            // var sign = this.CreateSignature(
            //     string_builders,
            //     apiSecret);
            //
            // props.Add("Signature", sign);
            // this.AppendPropsKeyedRequest(props);
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
 
