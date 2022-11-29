using System;
using System.Diagnostics;
using System.Security.Authentication;
using ClassLibrary1.Domain;
using HoubiClient;
using Huobi.SDK.Core.WSBase;
using Huobi.SDK.Core.WSBase.PrivateStreams;
using Huobi.SDK.Core.WSBase.PrivateStreams.Enums;
using HuobiMapper.Requests;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using HuobiMapper.USDTFutures.RestApi.Requests.Account;
using NUnit.Framework;

namespace ClassLibrary1.Test.Private
{
    public class PrivateStreamsTests: BaseStreamTest
    {        
        private string ContractCode = "BTC-USDT";

        public PrivateStreamsTests()
        {
            _websocketPrivate.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls11;
        } 
        
        [Test]
        public void AuthTest()
        {
            var auth = CombineSubscriberPrivate.CreateAuth(APIKEY, APISECRET, Environment.CurrentDirectory+@"\ws\signwshuobi.exe");
            var ord = CombineSubscriberPrivate.CreateOrdersSub("*", SubType.Subscribe);
            var pos = CombineSubscriberPrivate.CreatePositionsSub("*", SubType.Subscribe);
            _websocketPrivate.OnMessage += (sender, args) =>
            {
                var result = GZipDecompresser.Decompress(args.RawData);
                Debug.Print(result);
                IsTestFinish = IsDepthFinishTest();
            };
            _websocketPrivate.OnError += (sender, args) =>
            {
                var data = args;
                Debug.Print("~~~~~~~[Socket Error]~~~~~~~: " + args.Message);
            };
            _websocketPrivate.OnOpen += (sender, args) =>
            {
                var data = args;
                Debug.Print("~~~~~~~[Socket Opened]~~~~~~~");
                _websocketPrivate.Send(auth);
                _websocketPrivate.Send(ord);
                _websocketPrivate.Send(pos);
            };
            _websocketPrivate.OnClose += (sender, args) =>
            {
                Debug.Print("~~~~~~~[Socket Closed]~~~~~~~");
            };
            _websocketPrivate.Connect();
            AwaitFinishTest();
        }

        [Test]
        public void PlaceWsTest()
        {
            var auth = CombineSubscriberPrivate.CreateAuth(APIKEY, APISECRET,Environment.CurrentDirectory+@"\ws\signwshuobi.exe");
            var ord = CombineSubscriberPrivate.CreateOrdersSub("*", SubType.Subscribe);
            _websocketPrivate.OnMessage += (sender, args) =>
            {
                var result = GZipDecompresser.Decompress(args.RawData);
                Debug.Print(result);
                IsTestFinish = IsDepthFinishTest();
            };
            _websocketPrivate.OnError += (sender, args) =>
            {
                var data = args;
                Debug.Print("~~~~~~~[Socket Error]~~~~~~~: " + args.Message);
            };
            _websocketPrivate.OnOpen += (sender, args) =>
            {
                var data = args;
                Debug.Print("~~~~~~~[Socket Opened]~~~~~~~");
                _websocketPrivate.Send(auth);
                _websocketPrivate.Send(ord);
                
                var payload = new PlaceOrderRequest(ContractCode, 1, DirectionEnum.Buy, 200, OrderPriceTypeEnum.Limit){Price = 17000};
                var resultRequest = SendRequest(payload);
                var resultResponse = AccountComposition.HandLerGetPlaceOrderResponses(resultRequest);
            };
            _websocketPrivate.OnClose += (sender, args) =>
            {
                Debug.Print("~~~~~~~[Socket Closed]~~~~~~~");
            };
            _websocketPrivate.Connect();
            AwaitFinishTest();
        }
        
        private RestApiComposition AccountComposition = new RestApiComposition();

        public const string SignMethod = "HmacSHA256";
        public const string SignatureVersion = "2";
        public const string ClearHost = "api.hbdm.com";
        public const string APIKEY = "66fa8a46-1426ecd9-vqgdf4gsga-70aa2";
        public const string APISECRET = "d8acadf9-b9e9ac56-2b852e0c-09e41";
        // public const string APIKEY = "";
        // public const string APISECRET = "";
        private static RestApiComposition AccountCompositionStatic = new RestApiComposition();

        private RequestArranger _arranger = new RequestArranger();
        
        public string SendRequest(RequestPayload payload)
        {
            var client = new HoubiHttpClient(APIKEY, APISECRET);
            string response = string.Empty;
            
            var request = _arranger.Arrange(payload);
            if (request.Method == RequestMethod.POST)
                response = client.SendRequest(request.Query, payload.Properties);
            else if (request.Method == RequestMethod.GET)
                response = client.SendRequestPublic(request.Query, request.RawProperty);
            
            return response;
        }
    }
}