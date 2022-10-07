using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using ClassLibrary1.Domain;
using HuobiMapper.USDTFutures.MarketStreams;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using NUnit.Framework;

namespace ClassLibrary1.Test.Public
{
    public class MarketStreamsTests : BaseStreamTest
    {
        private ContractsMarketStreamsComposition _composition = new ContractsMarketStreamsComposition();

        public MarketStreamsTests() =>
            _websocket.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls12;

        [Test]
        public async Task SubIncrementalTest()
        {
            CombineSubscriber.DataType = true;
            /*var data_type = eventDataType.GetEnumMemberAttributeValue();*/
            var payload = CombineSubscriber.CreateEventStringre(EventDataType.None, MarketType.Market,
                symbolType: "btc-usdt",
                SubscribeType.Depth, SizeType.Size_20, "high_freq");

            _websocket.OnMessage += (sender, args) =>
            {
                var baseEvent = _composition.HandlerGetBaseEvent(args.Data);
                var eventType = baseEvent.EventType;
                switch (eventType)
                {
                    case EventType.Depth:
                        var ch = _composition.HandlerGetOrderDepthEvent(args.Data);
                        if (ch.Datatype != null)
                        {
                            if (ch.TypeEnum == EventDataType.Snapshot)
                            {
                                IsSnapshotFinish = ch.Ch.Ch.Length != 0 && ch.Ch.Ts != 0 && ch.Ch.Tick.Asks.Count != 0
                                                   && ch.Ch.Tick.Bids.Count != 0 && ch.Ch.Tick.Id != 0 &&
                                                   ch.Ch.Tick.Mrid != 0
                                                   && ch.Ch.Tick.Ts != 0 && ch.Ch.Tick.Version != 0 &&
                                                   ch.Ch.Tick.Ch.Length != 0
                                                   && ch.Ch.Tick.Event.Length != 0;
                            }

                            if (ch.TypeEnum == EventDataType.Incremental)
                            {
                                IsIncremetalfinish = ch.Ch.Tick.Asks.Count != 0 || ch.Ch.Tick.Bids.Count != 0;
                            }
                        }

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
            };
            _websocket.Connect();
            _websocket.Send(payload);

            AwaitFinishTest();
        }

        /*
        [Test]
        public async Task TradeTest()
        {
            CombineSubscriber.DataType = false;
            var payload = CombineSubscriber.CreateEventStringre(EventDataType.None, MarketType.Market,
                symbolType: "BTC-USDT",
                SubscribeType.Trade, SizeType.None, "detail");

            _websocket.OnMessage += (sender, args) =>
            {
                var baseEvent = _composition.HandlerGetBaseEvent(args.Data);
                var eventType = baseEvent.EventType;    
                switch (eventType)
                {
                    case EventType.Trade:
                        var trades = _composition.HandlerGetOrderTradeEvent(args.Data);
                        if (trades.TypeEnum is EventDataType.Snapshot)
                        {
                            IsSnapshotFinish = trades.Trades.Count != 0 && trades.Trades[0].Price != 0 &&
                                               trades.Trades[0].Qty != 0 && trades.Trades[0].Timestamp != 0 &&
                                               trades.Trades[0].TradeSide != TradeSide.None;
                        }

                        if (trades.TypeEnum is EventDataType.Incremental)
                        {
                            IsIncremetalFinish = trades.Trades.Count != 0 && trades.Trades[0].Price != 0 &&
                                                 trades.Trades[0].Qty != 0 && trades.Trades[0].Timestamp != 0 &&
                                                 trades.Trades[0].TradeSide != TradeSide.None;
                        }

                        break;
                }

                IsTestFinish = IsTradeFinishTest();
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
        }*/
    }

}
