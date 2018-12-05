using System;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class OhlcvHistoricalParameters
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        
        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }
        
        [JsonProperty("time_start")]
        public DateTime? TimeStart { get; set; }
        
        [JsonProperty("time_end")]
        public DateTime? TimeEnd { get; set; }
        
        /// <summary>
        /// 1-10000
        /// </summary>
        [JsonProperty("count")]
        public long? Count { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }
        
        [JsonProperty("convert")]
        public string Convert { get; set; }
    }
}
