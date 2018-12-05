using System;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class HistoricalQuoteParameters
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("time_start")]
        public DateTime? TimeStart { get; set; }

        [JsonProperty("time_end")]
        public DateTime? TimeEnd { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("convert")]
        public string Convert { get; set; }
    }
}
