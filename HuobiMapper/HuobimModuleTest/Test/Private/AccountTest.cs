using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using ClassLibrary1.Domain;
using HuobiMapper.Extensions;
using NUnit.Framework;
using HuobiMapper.USDTFutures.RestApi;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders;
using HuobiMapper.USDTFutures.RestApi.Requests.Account;


namespace ClassLibrary1.Test.Private
{
    public class AccountTest : BaseTests
    {
        private string Symbol = "BTC";
        private string ContractCode = "BTC-USDT";
        private DateTime From = DateTime.UtcNow.AddDays(-1);
        private DateTime To = DateTime.UtcNow;

        private RestApiComposition AccountComposition = new RestApiComposition();

        [Test]
        public void BalanceTest()
        {

            #region [Arrange]

            var payload = new AccountRequest();
            payload.Contractcode = ContractCode;
            #endregion

            #region [Action]

            var resultRequest = SendRequest(payload);
            var resultResponse = AccountComposition.HandLerGetPrivateResponse(resultRequest);

            #endregion

            #region [Assert]

            Assert.True(resultResponse.AccountData != null);
            Assert.True(resultResponse.AccountData[0].Symbol != null);
            Assert.True(resultResponse.AccountData[0].MarginBalance != 0);
            Assert.True(resultResponse.AccountData[0].MarginPosition != null);
            Assert.True(resultResponse.AccountData[0].MarginFrozen != 0);
            Assert.True(resultResponse.AccountData[0].MarginAvailable != 0);
            Assert.True(resultResponse.AccountData[0].ProfitReal != null);
            Assert.True(resultResponse.AccountData[0].ProfitUnreal != null);
            Assert.True(resultResponse.AccountData[0].RiskRate != 0);
            Assert.True(resultResponse.AccountData[0].WithdrawAvailable != 0);
            Assert.True(resultResponse.AccountData[0].LeverRate != 0);
            Assert.True(resultResponse.AccountData[0].AdjustFactor != 0);
            Assert.True(resultResponse.AccountData[0].MarginStatic != 0);
            Assert.True(resultResponse.AccountData[0].ContractCode != null);
            Assert.True(resultResponse.AccountData[0].MarginAsset != null);
            Assert.True(resultResponse.AccountData[0].MarginMod != null);
            Assert.True(resultResponse.AccountData[0].MarginAccount != null);
            Assert.True(resultResponse.AccountData[0].PositionMode != null);
            Assert.True(resultResponse.AccountData.Count != 0);
            Assert.True(resultResponse.Status != null);
            Assert.True(resultResponse.Ts != 0);

            Debug.Print($"NEEDED VALUE: {resultResponse.Serialize()}");

            #endregion
        }

        [Test]
        public void OrderHistory()
        {
            var payload = new GetHistoryOrdersRequests(ContractCode, TradeType.All, OrderStatusEnum.None, OrderType.AllOrders);
            var resultRequest = SendRequest(payload);
            var resultResponse = AccountComposition.HandLerGetGetHistoryOrdersResponses(resultRequest);
            Assert.True(resultResponse.Code == 200);
        }
        [Test]
        public void OpenOrderHistory()
        {
            var payload = new CurrentUnfilledOrderAcquisitionRequests(ContractCode);
            var resultRequest = SendRequest(payload);
            var resultResponse = AccountComposition.HandLerGetCurrentUnfilledOrderAcquisitionResponses(resultRequest);
            Assert.True(resultResponse.Data != null);
        }
        [Test]
        public void TradeHistory()
        {
            var payload = new GetHistoryOrdersRequests(ContractCode, TradeType.All, OrderStatusEnum.None, OrderType.OrderInFinishStatus);
            var resultRequest = SendRequest(payload);
            var resultResponse = AccountComposition.HandLerGetGetHistoryOrdersResponses(resultRequest);
            Assert.True(resultResponse.Code == 200);
        }
        [Test]
        public void PlaceOrder()
        {
            var payload = new PlaceOrderRequest(ContractCode, 1, DirectionEnum.Sell, 200, OrderPriceTypeEnum.Limit){Price = 16600.1m, ChannelCode = "AA3439564b"};
            var resultRequest = SendRequest(payload);
            var resultResponse = AccountComposition.HandLerGetPlaceOrderResponses(resultRequest);

            Assert.True(resultResponse.PlOrData != null);
        }
        [Test]
        public void CloseOrder()
        {
            var payloadPlace = new PlaceOrderRequest(ContractCode, 1, DirectionEnum.Buy, 200, OrderPriceTypeEnum.Limit){Price = 18000};
            var resultRequestPlace = SendRequest(payloadPlace);
            var resultResponsePlace = AccountComposition.HandLerGetPlaceOrderResponses(resultRequestPlace);
            
            var payload = new CancelanOrderRequests(ContractCode){ Orderid = resultResponsePlace.PlOrData.OrderIdStr};
            var resultRequest = SendRequest(payload);
            
            var resultResponse = AccountComposition.HandLerGetPlaceOrderResponses(resultRequest);
            Assert.True(resultResponse.PlOrData != null);
        }
    }
}