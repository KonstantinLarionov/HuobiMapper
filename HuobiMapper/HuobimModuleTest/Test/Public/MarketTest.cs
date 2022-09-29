using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using ClassLibrary1.Domain;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Requests;
using HuobiMapper.USDTFutures.RestApi.Requests.Market;
using NUnit.Framework;

namespace ClassLibrary1.Test.Public
{
    public class MarketTest : BaseTests

    {
        private DateTime From = DateTime.UtcNow.AddDays(-1);
        private DateTime To = DateTime.UtcNow;
        private Period Period = Period.OneMinute;
        private string Contractcode = "BTC-USDT";
        private RestApiComposition MarketComposition = new RestApiComposition();
        
        [Test]
        public void CurrencyTest()
        {
            #region [Arrange]

            var payload = new CurrencyRequest();

            #endregion

            #region [Action]

            var resultRequest = SendRequest(payload);   
            var resultResponse = MarketComposition.HandLerGetCurrencyResponse(resultRequest);

            #endregion

            #region [Assert]

            Assert.True(resultResponse.Ts != 0);
            Assert.True(resultResponse.Data != null);
            Assert.True(resultResponse.Status != null);
            Assert.True(resultResponse.Data.Count != 0);

            Debug.Print($"NEEDED VALUE: {resultResponse.Data[0].Serialize()}");

            #endregion
        }

        [Test]

        public void KlineTest()
        {
            #region [Arrange]

            var payload = new KlineRequest(Contractcode, Period);
            #endregion

            #region [Action]

            var resultRequest = SendRequest(payload);
            var resultResponse = MarketComposition.HandLerGetDataKlineResponse(resultRequest);
            #endregion
            //{"err-code":"invalid-request","err-msg":"invalid symbol","status":"error","ts":1662796561249}
            #region[Assert]

           
            Assert.True(resultResponse.Tick[0].Amount != 0);
            Assert.True(resultResponse.Tick[0].Count != 0);
            Assert.True(resultResponse.Tick[0].High != 0);
            Assert.True(resultResponse.Tick[0].Low != 0);
            Assert.True(resultResponse.Tick[0].Close != 0);
            Assert.True(resultResponse.Tick[0].Vol != 0);
            Assert.True(resultResponse.Tick[0].Open != 0);
            Assert.True(resultResponse.Tick[0].Id != 0);
            Assert.True(resultResponse.Tick[0].Tradeturnover != 0);
            Assert.True(resultResponse.Tick.Count != 0);
            Assert.True(resultResponse.Ch != null);
            Assert.True(resultResponse.Status != null);
            Assert.True(resultResponse.Ts != 0);
            Assert.True(resultResponse.StatusEnum != 0);
            
            
            Debug.Print($"NEEDED VALUE: {resultResponse.Tick[0].Serialize()}");
            #endregion

        }
}
} 