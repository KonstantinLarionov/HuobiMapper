using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class TradeRequest : KeyedRequestPayload
    {
        public TradeRequest(string symbol, TradeType tradeType)
        {
            Symbol = symbol;
            TradeType = tradeType;
        }

        public string Symbol { get; set; }
        public TradeType TradeType { get; set; }
        public string Pair { get; set; }
        private long? _startTime {
            get
            {
                return StartTime?.ToUnixTimeMilliseconds(); 
            }
        }
        private long? _endTime {
            get
            {
                return EndTime?.ToUnixTimeMilliseconds();
            }
        }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Direct? Direct { get; set; }
        public long? From_id { get; set; }
        internal override string EndPoint { get; } = "/linear-swap-api/v3/swap_matchresults";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
        public override Dictionary<string, string> Properties
        {
            get
            {   
                var def = new Dictionary<string, string>();
                
                def.AddStringIfNotEmptyOrWhiteSpace("contract", Symbol);
                def.AddEnum("trade_type", TradeType);
                def.AddStringIfNotEmptyOrWhiteSpace("pair", Pair);
                def.AddSimpleStructIfNotNull("start_time", _startTime);
                def.AddSimpleStructIfNotNull("end_time", _endTime);
                def.AddEnumIfNotNull("direct", Direct);
                def.AddSimpleStructIfNotNull("from_id", From_id);
                
                return def;
            }
        } 
    }

    public enum Direct
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "prev")]
        Prev,
        [EnumMember(Value = "next")]
        Next
    }
}