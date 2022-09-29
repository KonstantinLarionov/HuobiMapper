using System;
using System.Security.Authentication;
using ClassLibrary1.Domain;
using HuobiMapper.USDTFutures.PrivateStreams;
using HuobiMapper.USDTFutures.PrivateStreams.Data.Enums;
using HuobiMapper.USDTFutures.PrivateStreams.Events;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.Test.Private
{

    public class PrivateStreamsTests : BaseStreamTest
    {
        private ContractsPrivateStreams _composition = new ContractsPrivateStreams();
        //private ContractsPrivateStreamsComposition _composition = new ContractsPrivateStreamsComposition();

        public PrivateStreamsTests() =>
            _websocket.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls12;

        [Test]
        public void LoginWsTest()
        {

            var id = DateTime.UtcNow.AddMinutes(4).ToUnixTimeSeconds();
            var payload = CombineSubscriber.CreateEventAuth("a5671fd6-5cd96920-7aacdd9d-bewr5drtmh",
                "3eca0866-af09c558-4b95cec3-0558f",
                DateTime.UtcNow.AddMinutes(4).ToUnixTimeSeconds());

            _websocket.OnMessage += (sender, args) =>
            {
                var baseEvent = _composition.HandlerGetBaseEvent(args.Data);
                var eventType = baseEvent.EventType;
                switch (eventType)
                {
                    case EventType.UserLogin:
                        IsLoginWsFinish = baseEvent.Result.StatusEnum is StatusBaseEvent.Success;
                        break;
                }

                IsTestFinish = IsLoginWsFinish;
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


        /*[Test]
        public void AOPWsTest()
        {
            //ПИЗДЕЦ ПО ДРУГОМУ НЕ НАЗВАТЬ (в ресте нужно местное время, а в сокете UTC) найдено путем проб и хуеб.

            var id = DateTime.UtcNow.AddMinutes(1).ToUnixTimeSeconds();
            var payloadAuth = CombineSubscriber.CreateEventAuth("a5671fd6-5cd96920-7aacdd9d-bewr5drtmh",
                "3eca0866-af09c558-4b95cec3-0558f",
                DateTime.UtcNow.AddMinutes(1).ToUnixTimeSeconds());
            var payloadAOP =
                CombineSubscriber.CreateEventString(EventType.AccountOrderPosition, SubscribeType.Subscribe);

            _websocket.OnMessage += (sender, args) =>
            {
                var baseEvent = _composition.HandlerGetBaseEvent(args.Data);
                var eventType = baseEvent.EventType;
                switch (eventType)
                {
                    case EventType.UserLogin:
                        IsLoginWsFinish = baseEvent.Result.StatusEnum is StatusBaseEvent.Success;
                        break;
                    case EventType.AccountOrderPosition:
                        var res = _composition.HandlerGetAOPEvent(args.Data);
                        IsAOPFinish = res.Accounts != null && res.Orders != null && res.Positions != null;
                        break;
                }

                IsTestFinish = IsLoginWsFinish && IsAOPFinish;
            };
            _websocket.OnError += (sender, args) =>
            {
                var data = args;
            };
            _websocket.OnOpen += (sender, args) =>
            {
                var data = args;
                _websocket.Send(payloadAuth);
                Thread.Sleep(2000);
                _websocket.Send(payloadAOP);
            };
            _websocket.Connect();

            AwaitFinishTest();
        }*/
    }
}