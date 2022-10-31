using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Extensions;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data
{
    public class CurrencysData
    {
        [JsonConstructor]
        public CurrencysData(string symbol, string contractCode,  decimal contractSize, decimal pricetick, string deliverydate, string deliverytime,
            string createdate, int contractstatus, string settlementdate, string supportmarginmode, string businesstype, string pair, string contracttype)
        {
            Symbol = symbol;
            ContractCode = contractCode;
            ContractSize = contractSize;
            PriceTick = pricetick;
            DeliveryDate = deliverydate;
            DeliveryTime =  deliverytime;
            CreateDate = createdate;
            ContractStatus = contractstatus;
            ContractStatusEnum = (ContractStatusEnum)ContractStatus;
            SettlementDate =settlementdate;
            SupportMarginMode = supportmarginmode;
            SupportMarginModeEnum = SupportMarginMode.ToEnum<SupportMarginModeEnum>();
            BusinessType = businesstype;
            Pair = pair;
            ContractType = contracttype;
            ContractTypeEnum = ContractType.ToEnum<ContractTypeEnum>();
        }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }
        [JsonProperty("contract_size")]
        public decimal ContractSize { get; set; }
        [JsonProperty("price_tick")]
        public decimal PriceTick { get; set; }
        [JsonProperty("delivery_date")]
        public string DeliveryDate { get; set; }
        [JsonProperty("delivery_time")]
        public string DeliveryTime { get; set; }
        [JsonProperty("create_date")]
        public string CreateDate { get; set; }
        [JsonProperty("contract_status")]
        public int ContractStatus { get; set; }

        public ContractStatusEnum ContractStatusEnum { get; set; }

        [JsonProperty("settlement_date")]
        public string SettlementDate { get; set; }
        [JsonProperty("support_margin_mode")]
        public string SupportMarginMode { get; set; }
        public SupportMarginModeEnum SupportMarginModeEnum { get; set; }

        [JsonProperty("business_type")]
        public string BusinessType { get; set; }
        [JsonProperty("pair")]
        public string Pair { get; set; }
        [JsonProperty("contract_type")]
        public string ContractType { get; set; }
        public ContractTypeEnum ContractTypeEnum { get; set; }

    }
    
}