using WebSocketSharp;
using System.Threading;
using NUnit.Framework;

namespace ClassLibrary1.Domain
{
    public class BaseStreamTest
    {
        protected WebSocket _websocket = new WebSocket("wss://api.hbdm.com");
        protected bool IsTestFinish = false;
        protected bool IsSnapshotFinish = false;
        protected bool IsIncremetalfinish = false;
        protected bool IsLoginWsFinish = false;
        protected bool IsAOPFinish = false;


        protected bool IsBookFinishTest() => IsIncremetalfinish && IsSnapshotFinish;
        protected bool IsTradeFinishtest() => IsIncremetalfinish && IsSnapshotFinish;

        protected void AwaitFinishTest()
        {
            while (true)
            {
                if (IsTestFinish)
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }
    }
}