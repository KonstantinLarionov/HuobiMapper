//using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace HoubiClient
{
    public class HoubiHttpClient
    {
               private readonly string HUOBI_HOST = string.Empty;
      
        private readonly string HUOBI_HOST_URL = string.Empty;
       
        private const string HUOBI_SIGNATURE_METHOD = "HmacSHA256";
     
        private const int HUOBI_SIGNATURE_VERSION = 2;
      
        private readonly string ACCESS_KEY = string.Empty;
       
        private readonly string SECRET_KEY = string.Empty;

        //private RestClient client;
        private HttpClient _httpClient;
        
        public HoubiHttpClient(string accessKey, string secretKey, string huobi_host = "api.hbdm.com")
        {
            ACCESS_KEY = accessKey;
            SECRET_KEY = secretKey;
           // HUOBI_HOST = huobi_host;
            HUOBI_HOST_URL = "https://" + huobi_host;
           	Uri uri = new Uri(HUOBI_HOST_URL);
            HUOBI_HOST = uri.Host;
         
            // if (string.IsNullOrEmpty(ACCESS_KEY))
            //     throw new ArgumentException("ACCESS_KEY Cannt Be Null Or Empty");
            // if (string.IsNullOrEmpty(SECRET_KEY))
            //     throw new ArgumentException("SECRET_KEY  Cannt Be Null Or Empty");
            // if (string.IsNullOrEmpty(HUOBI_HOST))
            //     throw new ArgumentException("HUOBI_HOST  Cannt Be Null Or Empty");
            //client = new RestClient(HUOBI_HOST_URL);
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(HUOBI_HOST_URL);
            
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");
            //client.AddDefaultHeader("Content-Type", "application/json");
            //client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");
        }
        
        // public string SendRequest(string resourcePath, string parameters = "")
        // {
        //     parameters = UriEncodeParameterValue(GetCommonParameters() + parameters);//请求参数
        //     var sign = GetSignatureStr(Method.GET, HUOBI_HOST, resourcePath, parameters);//签名
        //     parameters += $"&Signature={sign}";
        //
        //     var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
        //     Console.WriteLine(url);
        //     var request = new RestRequest(url, Method.GET);
        //     var result = client.Execute(request);
        //     return result.Content;
        // }
        public string SendRequest(string resourcePath, object postParameters)
        {
            var parameters = UriEncodeParameterValue(GetCommonParameters());
            var sign = GetSignatureStr(HttpMethod.Post, HUOBI_HOST, resourcePath, parameters);
            parameters += $"&Signature={sign}";

            var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
            // var request = new RestRequest(url, Method.POST);
            // request.AddJsonBody(postParameters);
            // foreach (var item in request.Parameters)
            // {
            //     item.Value = item.Value.ToString();
            // }
            // var result = client.Execute(request);
            
            var json = JsonConvert.SerializeObject(postParameters);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(url, data).GetAwaiter().GetResult();
            var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            
            return result;
        }
        public string SendRequestPublic(string resourcePath, string parameters = "")
        {
            var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
            // var request = new RestRequest(url, Method.GET);
            var result = _httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            return result;
        }
        private string GetCommonParameters()
        {
            return $"AccessKeyId={ACCESS_KEY}&SignatureMethod={HUOBI_SIGNATURE_METHOD}&SignatureVersion={HUOBI_SIGNATURE_VERSION}&Timestamp={DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}";
        }
        private string UriEncodeParameterValue(string parameters)
        {
            var sb = new StringBuilder();
            var paraArray = parameters.Split('&');
            var sortDic = new SortedDictionary<string, string>();
            foreach (var item in paraArray)
            {
                var para = item.Split('=');
                sortDic.Add(para.First(), UrlEncode(para.Last()));
            }
            foreach (var item in sortDic)
            {
                sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
            }
            return sb.ToString().TrimEnd('&');
        }
        private string UrlEncode(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in str)
            {
                if (HttpUtility.UrlEncode(c.ToString(), Encoding.UTF8).Length > 1)
                {
                    builder.Append(HttpUtility.UrlEncode(c.ToString(), Encoding.UTF8).ToUpper());
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
        private static string CalculateSignature256(string text, string secretKey)
        {
            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(hashmessage);
            }
        }
        private string GetSignatureStr(HttpMethod method, string host, string resourcePath, string parameters)
        {
            var sign = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(method.ToString().ToUpper()).Append("\n")
                .Append(host).Append("\n")
                .Append(resourcePath).Append("\n");
            var paraArray = parameters.Split('&');
            List<string> parametersList = new List<string>();
            foreach (var item in paraArray)
            {
                parametersList.Add(item);
            }
            parametersList.Sort(delegate(string s1, string s2) { return string.CompareOrdinal(s1, s2); });
            foreach (var item in parametersList)
            {
                sb.Append(item).Append("&");
            }
            sign = sb.ToString().TrimEnd('&');
            sign = CalculateSignature256(sign, SECRET_KEY);
            return UrlEncode(sign);
        }
    }
    
    public class WSChAuthData
    {
        public string op { get { return "auth"; } }

        public string type { get { return "api"; } }

        [JsonProperty("AccessKeyId")]
        public string accessKeyId { get; set; }

        [JsonProperty("SignatureMethod")]
        public string signatureMethod { get { return "HmacSHA256"; } }

        [JsonProperty("SignatureVersion")]
        public string signatureVersion { get { return "2"; } }

        [JsonProperty("Timestamp")]
        public string timestamp { get; set; }

        [JsonProperty("Signature")]
        public string signature { get; set; }

    }
}
