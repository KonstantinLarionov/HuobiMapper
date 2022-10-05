using System.Collections.Generic;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition
{
    public class CurrentUnfilledOrderAcquisition
    {   [JsonConstructor]
        public CurrentUnfilledOrderAcquisition(List<Orders> orders, int totalPage, int currentPage, int totalSize)
        {
            Orders = orders;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            TotalSize = totalSize;
        }
        [JsonProperty("orders")]
        public List<Orders> Orders { get; set; }
        [JsonProperty("total_page")]
        public int TotalPage { get; set; }
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("total_size")]
        public int TotalSize { get; set; }
    }
}