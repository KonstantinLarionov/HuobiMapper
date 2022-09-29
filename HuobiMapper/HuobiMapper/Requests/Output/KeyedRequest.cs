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
    
    {   HMACSHA256 _hmacsha256;
        public DateTime now = DateTime.Now;
        public string sign = String.Empty;
        public string SignatureMethod = "HmacSHA256";
        public string SignatureVersion = "2";
        public string Orderid = "1234567890";
        public string sign1 = String.Empty;
        public string timestampEnc;
        public string baseUrl = "https://api.hbdm.com";
        public KeyedRequest([NotNull] RequestPayload requestPayload, [NotNull] string apiKey,
            [NotNull] string apiSecret, [NotNull] long timestamp)
            : base(requestPayload, apiKey)


        {

            
            /*
            if (requestPayload.Method is RequestMethod.GET || requestPayload.Method is RequestMethod.DELETE ||
                requestPayload.Method is RequestMethod.PUT)

            {  
                var signstr = requestPayload.EndPoint + base.GenerateParametersString(requestPayload.Properties) +
                              timestamp;
                sign = CreateSignature1(signstr, apiSecret);
                Headers = new Dictionary<string, string>()
                {
                    { "AccessKeyId", apiKey },
                    { "Timestamp", timestamp.ToString() },
                    { "SignatureVersion", SignatureVersion },
                    { "order-id", Orderid },
                    { "SignatureMethod", SignatureMethod },
                    { "x-huobi-request-signature", sign1 },
                };

            }

            
            else if (requestPayload.Method is RequestMethod.POST)
            {
               
                sign = CreateSignature1("POST\n"+baseUrl+"\n"+
                    requestPayload.EndPoint +"\n"+"AccessKeyId=" + apiKey + "&SignatureMethod=" + SignatureMethod + "&SignatureVersion" +
                    SignatureVersion + "&Timestamp=" + timestamp, apiSecret);
                var timeSt = Timestamp(timestamp);
                sign1 = govnoebychee(requestPayload.EndPoint +"?"+ "AccessKeyId=" + apiKey /*+"&order-id="+ Orderid#1# +
                                        "&SignatureMethod=" + SignatureMethod +
                                        "&SignatureVersion" +
                                        SignatureVersion + "&Timestamp=" + timeSt +"&Signature=", sign);
                
                Headers = new Dictionary<string, string>()
                {
                    { "AccessKeyId", apiKey },
                    { "Timestamp", timestamp.ToString() },
                    { "SignatureVersion", SignatureVersion },
                    { "order-id", Orderid },
                    { "SignatureMethod", SignatureMethod },
                    { "x-huobi-request-signature", sign1 },
                };

            }
           
        }*/
        public KeyedRequest (string key)
        {
            byte[] keyBuffer = Encoding.UTF8.GetBytes(key);
            _hmacsha256 = new HMACSHA256(keyBuffer);
        }
        public string Sign(string method, string host, string path, string parameters)
        {
            if (string.IsNullOrEmpty(method) || string.IsNullOrEmpty(host)
                                             || string.IsNullOrEmpty(path) || string.IsNullOrEmpty(parameters))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append($"{method}\n");
            sb.Append($"{host}\n");
            sb.Append($"{path}\n");
            sb.Append(parameters);

            return Sign(sb.ToString());
        }

        private string Sign(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            byte[] inputBuffer = Encoding.UTF8.GetBytes(input);

            byte[] hashedBuffer = _hmacsha256.ComputeHash(inputBuffer);

            return Convert.ToBase64String(hashedBuffer);
        }

        #region IDisposable Support
        private bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _hmacsha256.Dispose();
                }

                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion


    }
        /*
        public string Timestamp (long timestamp)
        {
            var time = timestamp.ToDateTimeFromUnixTimeSeconds().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            return timestampEnc = Uri.EscapeDataString(time);
        }
         
        public string govnoebychee(string message, string sign)
        {
            return message + sign;
        }
        public static string CreateSignature1(string message, string secret)
        {
            var signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return   Convert.ToBase64String(signatureBytes);
        }

        private static byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }
        */
       
        
        public sealed override IReadOnlyDictionary<string, string> Headers { get; }
        public sealed override string Query
        {
            get { return sign; }
        }
    }
}
 
