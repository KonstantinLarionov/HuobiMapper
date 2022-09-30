using System.Dynamic;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.AccountInfo
{
    public class AccountData
    {
        [JsonConstructor]

        public AccountData(string symbol, decimal marginBalance, decimal marginPosition, decimal marginFrozen, decimal marginAvailable, decimal profitReal, decimal profitUnreal, decimal riskRate, decimal withdrawAvailable, decimal liquidationPrice, decimal leverRate, decimal adjustFactor, decimal marginStatic, string contractCode, string marginAsset, string marginMod, string marginAccount, string positionMode)

        {
            Symbol = symbol;
            MarginBalance = marginBalance;
            MarginPosition = marginPosition;
            MarginFrozen = marginFrozen;
            MarginAvailable = marginAvailable;
            ProfitReal = profitReal;
            ProfitUnreal = profitUnreal;
            RiskRate = riskRate;
            WithdrawAvailable = withdrawAvailable;
            LiquidationPrice = liquidationPrice;
            LeverRate = leverRate;
            AdjustFactor = adjustFactor;
            MarginStatic = marginStatic;
            ContractCode = contractCode;
            MarginAsset = marginAsset;
            MarginMod = marginMod;
            MarginAccount = marginAccount;
            PositionMode = positionMode;
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        
        [JsonProperty ("margin_balance")]
        public decimal MarginBalance { get; set; }
        
        [JsonProperty("margin_position")]
        public decimal MarginPosition { get; set; }
        
        [JsonProperty("margin_frozen")]
        public decimal MarginFrozen { get; set; }
        
        [JsonProperty("margin_available")]
        public decimal MarginAvailable { get; set; }
        
        [JsonProperty("profit_real")]
        public decimal ProfitReal { get; set; }

        [JsonProperty("profit_unreal")]
        public decimal ProfitUnreal { get; set; }
        
        [JsonProperty("risk_rate")]
        public decimal RiskRate { get; set; }
        
        [JsonProperty("withdraw_available")]
        public decimal WithdrawAvailable { get; set; }
        
        [JsonProperty("liquidation_price")]
        public decimal LiquidationPrice { get; set; }
        
        [JsonProperty("lever_rate")]
        public decimal LeverRate { get; set; }
        
        [JsonProperty("adjust_factor")]
        public decimal AdjustFactor { get; set; }
        
        [JsonProperty("AdjustFactor")]
        public decimal MarginStatic { get; set; }
        
        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }
        
        [JsonProperty("margin_asset")]
        public string MarginAsset { get; set; }
        
        [JsonProperty("margin_mode")]
        public string MarginMod { get; set; }
        
        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }
        
        [JsonProperty("position_mode")]
        public string PositionMode { get; set; }

    }
}