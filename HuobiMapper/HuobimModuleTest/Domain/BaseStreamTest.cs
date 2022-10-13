using WebSocketSharp;
using System.Threading;


namespace ClassLibrary1.Domain
{
    public class BaseStreamTest
    {
        protected WebSocket _websocket = new WebSocket("wss://api.hbdm.com/linear-swap-ws");
        protected bool IsTestFinish = false;
        protected bool IsSnapshotFinish = false;
        protected bool IsIncremetalfinish = false;
        protected bool IsLoginWsFinish = false;
        protected bool IsAOPFinish = false;


        protected bool IsDepthFinishTest() => IsIncremetalfinish && IsSnapshotFinish;
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