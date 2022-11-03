using System;
using System.Diagnostics;
using System.Security.Authentication;
using ClassLibrary1.Domain;
using Huobi.SDK.Core.WSBase;
using Huobi.SDK.Core.WSBase.PrivateStreams;
using Huobi.SDK.Core.WSBase.PrivateStreams.Enums;
using NUnit.Framework;

namespace ClassLibrary1.Test.Private
{
    public class PrivateStreamsTests: BaseStreamTest
    {
        public PrivateStreamsTests()
        {
            _websocketPrivate.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls11;
        }

        public const string APIKEY = "66fa8a46-1426ecd9-vqgdf4gsga-70aa2";
        public const string APISECRET = "d8acadf9-b9e9ac56-2b852e0c-09e41";
        
        [Test]
        public void AuthTest()
        {
            var auth = CombineSubscriberPrivate.CreateAuth(APIKEY, APISECRET);
            var ord = CombineSubscriberPrivate.CreateOrdersSub("", SubType.Subscribe);
            var pos = CombineSubscriberPrivate.CreatePositionsSub("", SubType.Subscribe);
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
    }
}