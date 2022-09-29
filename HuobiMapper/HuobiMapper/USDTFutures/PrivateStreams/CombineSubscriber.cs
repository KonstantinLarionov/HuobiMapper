using System;
using System.Security.Cryptography;
using System.Text;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.PrivateStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.PrivateStreams
{
    public static class CombineSubscriber
    {
        public static string CreateEventAuth(string apiKey, string secretKey, long expiry)
        {
            var sign = CreateSignature(secretKey, apiKey + expiry);
            var result = new
            {
                method = $"{EventType.UserLogin.GetEnumMemberAttributeValue()}.{SubscribeType.Auth.GetEnumMemberAttributeValue()}",
                @params = new object[]{ "API", apiKey, sign, expiry },
                id = DateTime.UtcNow.AddMinutes(4).ToUnixTimeSeconds()
            };
            return JsonConvert.SerializeObject(result);
        }
        private static string CreateSignature(string secret, string message)
        {
            var signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return ByteArrayToString(signatureBytes);   
        }
        private static byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            { return hash.ComputeHash(messageBytes); }
        }
        private static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
            { hex.AppendFormat("{0:x2}", b); }
            return hex.ToString();
        }
        
        public static string CreateEventString(EventType eventType, SubscribeType subType, params string[] param)
        {
            var result = new
            {
                id = DateTime.UtcNow.AddMinutes(4).ToUnixTimeSeconds(),
                method = $"{eventType.GetEnumMemberAttributeValue()}.{subType.GetEnumMemberAttributeValue()}",
                @params = param,
            };
            return JsonConvert.SerializeObject(result);
        }
    }
}