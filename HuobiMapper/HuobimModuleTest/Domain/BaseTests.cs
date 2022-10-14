using System;
using System.Xml.XPath;
using HuobiMapper.Requests;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi;
using HuobiMapper.USDTFutures.RestApi.Requests.Market;
using RestSharp;

namespace ClassLibrary1.Domain
{
    public class BaseTests
    {
        public const string SignMethod = "HmacSHA256";
        public const string SignatureVersion = "2";
        public const string ClearHost = "api.hbdm.com";
        public const string APIKEY = "66fa8a46-1426ecd9-vqgdf4gsga-70aa2";
        public const string APISECRET = "d8acadf9-b9e9ac56-2b852e0c-09e41";
        private static RestApiComposition AccountCompositionStatic = new RestApiComposition();

        private RequestArranger _arranger =
            new RequestArranger("66fa8a46-1426ecd9-vqgdf4gsga-70aa2",
                "d8acadf9-b9e9ac56-2b852e0c-09e41",
                ClearHost,
                SignMethod,
                SignatureVersion, () =>
                {
                    var request = new RequestArranger().Arrange(new TimestampRequest());
                    var req = new RestRequest(request.Query, MapRequestMethodStatic(request.Method));

                    if (request.Body != null)
                    {
                        req.RequestFormat = DataFormat.Json;
                        req.AddJsonBody(request.Body);
                    }

                    if (request.Headers != null)
                    {
                        foreach (var header in request.Headers)
                        {
                            req.AddHeader(header.Key, header.Value);
                        }
                    }
                    var result = clientStatic.Execute(req)?.Content;
                    var timestamp = AccountCompositionStatic.HandLerGetTimestampResponses(result);
                    
                    return timestamp.Timestamp;
                });
        private RestClient client = new RestClient("https://api.hbdm.com");
        private static RestClient clientStatic = new RestClient("https://api.hbdm.com");

        public string SendRequest(RequestPayload payload)
        {
            var request = _arranger.Arrange(payload);
            var req = new RestRequest(request.Query, MapRequestMethod(request.Method));

            if (request.Body != null)
            {
                req.RequestFormat = DataFormat.Json;
                req.AddJsonBody(request.Body);
            }

            if (request.Headers != null)
            {
                foreach (var header in request.Headers)
                {
                    req.AddHeader(header.Key, header.Value);
                }
            }
            var result = client.Execute(req)?.Content;
            return (result);
        }
        private Method MapRequestMethod(RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.GET:
                    return Method.GET;
                case RequestMethod.POST:
                    return Method.POST;
                case RequestMethod.PUT:
                    return Method.PUT;
                case RequestMethod.DELETE:
                    return Method.DELETE;
                default:
                    throw new NotImplementedException();
            }
        }
        private static Method MapRequestMethodStatic(RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.GET:
                    return Method.GET;
                case RequestMethod.POST:
                    return Method.POST;
                case RequestMethod.PUT:
                    return Method.PUT;
                case RequestMethod.DELETE:
                    return Method.DELETE;
                default:
                    throw new NotImplementedException();
            }
        }
    }
    
}