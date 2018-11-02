using System;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class OhlcvHistoricalParams
    {
        public long Id { get; set; }
        public string Symbol { get; set; }
        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }
        [JsonProperty("time_start")]
        public DateTime TimeStart { get; set; }
        [JsonProperty("time_end")]
        public DateTime TimeEnd { get; set; }
        public long Count { get; set; }
        public string Interval { get; set; }
        public string Convert { get; set; }
    }
}
