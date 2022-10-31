using Huobi.SDK.Core.WSBase.PrivateStreams.Enums;
using HuobiMapper.Extensions;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Data.PositionsSubs
{
    public class PositionData
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("contract_code")]
        public string ContractCode { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("frozen")]
        public int Frozen { get; set; }

        [JsonProperty("cost_open")]
        public double CostOpen { get; set; }

        [JsonProperty("cost_hold")]
        public double CostHold { get; set; }

        [JsonProperty("profit_unreal")]
        public double ProfitUnreal { get; set; }

        [JsonProperty("profit_rate")]
        public double ProfitRate { get; set; }

        [JsonProperty("profit")]
        public double Profit { get; set; }

        [JsonProperty("position_margin")]
        public double PositionMargin { get; set; }

        [JsonProperty("lever_rate")]
        public int LeverRate { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
        public PositionDirection DirectionEnum {
            get
            {
                return Direction.ToEnum<PositionDirection>();
            }
        }

        [JsonProperty("last_price")]
        public double LastPrice { get; set; }

        [JsonProperty("margin_asset")]
        public string MarginAsset { get; set; }

        [JsonProperty("margin_mode")]
        public string MarginMode { get; set; }
        public PositionMarginMode MarginModeEnum {
            get
            {
                return MarginMode.ToEnum<PositionMarginMode>();
            }
        }

        [JsonProperty("margin_account")]
        public string MarginAccount { get; set; }

        [JsonProperty("position_mode")]
        public string PositionMode { get; set; }
        public PositionMode PositionModeEnum {
            get
            {
                return PositionMode.ToEnum<PositionMode>();
            }
        }
    }
}