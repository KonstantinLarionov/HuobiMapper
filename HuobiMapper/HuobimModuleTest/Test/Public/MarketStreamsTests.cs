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
          var id = Guid.NewGuid().ToString();
          var payload= CombineSubscriber.CreateEventStringre(MarketType.Market,SymbolType.btcusdt,SubscribeType.Depth,SizeType.Size_20,symbol)
          _websocket.OnMessage += (sender, args) =>
          {
              var baseEvent = _composition.HandlerGetBaseEvent(args.Data);
              var eventType = baseEvent.EventType;
              switch (eventType)
              {
                  case EventType.Depth:
                      var book = _composition.HandlerGetOrderBookEvent(args.Data);
                      if (book.Datatype != null)
                      {
                          if (book.TypeEnum == EventDataType.Snapshot)
                          {
                              IsSnapshotFinish = book.Datatype.Length != 0 && book.Id!= 0 && book.Datatype. != 0 && book.Book.Bids[0].Qty != 0;
                          }

                          if (book.TypeEnum == EventDataType.Incremental)
                          {
                              IsIncremetalFinish = book.Book.Asks.Count != 0 || book.Book.Bids.Count != 0;
                          }
                      }
                      break;
              }


          }
        }
    }
}