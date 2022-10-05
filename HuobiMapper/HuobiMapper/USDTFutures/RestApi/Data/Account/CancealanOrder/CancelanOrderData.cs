using System.Collections.Generic;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.CancealanOrder
{
    public class CancelanOrderdata
    {
        [JsonConstructor]
        public CancelanOrderdata(string successes,List<CancelanOrderErrors> errors)
        {
            Successes = successes;
            Errors = errors;
        }
        [JsonProperty("successes")]
        public string Successes { get; set; }
        
        [JsonProperty("errors")]
        public List<CancelanOrderErrors> Errors { get; set; }
       
    }
}