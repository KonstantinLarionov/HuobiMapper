using System;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Domain;
using Huobi.SDK.Core.WSBase;
using HuobiMapper.USDTFutures.MarketStreams;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using NUnit.Framework;

namespace ClassLibrary1.Test.Public
{
    public class MarketStreamsTests : BaseStreamTest
    {
        private ContractsMarketStreamsComposition _composition = new ContractsMarketStreamsComposition();

        // public MarketStreamsTests() =>
        //     _websocket.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls12;

        [Test]
        public async Task SubIncrementalTest()
        {
            CombineSubscriber.DataType = true;
            /*var data_type = eventDataType.GetEnumMemberAttributeValue();*/
            var payload = CombineSubscriber.CreateDepthSub("BTC-USDT", EventType.Depth, 150, EventDataType.Incremental);
            
            _websocket.OnMessage += (sender, args) =>
            {
                    string result = GZipDecompresser.Decompress(args.RawData);
                    var baseEvent = _composition.HandlerGetBaseEvent(result);
                    var eventType = baseEvent.EventType;
                    switch (eventType)
                    {
                        case EventType.Depth:
                            var ch = _composition.HandlerGetOrderDepthEvent(result);
                            break;
                    }

                    IsTestFinish = IsDepthFinishTest();
            };
            _websocket.OnError += (sender, args) =>
            {
                var data = args;
            };
            _websocket.OnOpen += (sender, args) =>
            {
                var data = args;
                _websocket.Send(payload);

            };
            _websocket.Connect();

            AwaitFinishTest();
        }

        
        [Test]
        public async Task TradeTest()
        {
            CombineSubscriber.DataType = false;
            var payload = CombineSubscriber.CreateTicksSub("BTC-USDT", EventType.Trade);

            _websocket.OnMessage += (sender, args) =>
            {
                string result = GZipDecompresser.Decompress(args.RawData);
                var baseEvent = _composition.HandlerGetBaseEvent(result);
                var eventType = baseEvent.EventType;    
                switch (eventType)
                {
                    case EventType.Trade:
                        var trades = _composition.HandlerGetOrderTradeEvent(result);
                       break;
                }

            };
            _websocket.OnError += (sender, args) =>
            {
                var data = args;
            };
            _websocket.OnOpen += (sender, args) =>
            {
                var data = args;
            };
            _websocket.Connect();
            _websocket.Send(payload);

            AwaitFinishTest();
        }
    }

}
