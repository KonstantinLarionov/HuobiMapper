using System;
using HuobiMapper.Requests;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using RestSharp;

namespace ClassLibrary1.Domain
{
    public class BaseTests
    {
        private RequestArranger _arranger = 
            new RequestArranger("ae81e784-6c5b8945-h6n2d4f5gh-6d005","3d9e3b4a-0d4f32c2-df34006e-9b650");
        private RestClient client = new RestClient("https://api.hbdm.com");

        protected string SendRequest(RequestPayload payload)
        {
            // var h = new Di  ctionary<string, string> { { "Referer", "Cscalp" } };
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
    }
    
}