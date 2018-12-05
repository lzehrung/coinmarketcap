using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class OhlcvHistoricalResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quotes")]
        public QuoteElement[] Quotes { get; set; }
    }

    public class QuoteElement
    {
        [JsonProperty("time_open")]
        public DateTimeOffset? TimeOpen { get; set; }

        [JsonProperty("time_close")]
        public DateTimeOffset? TimeClose { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, Ohlcv> Quote { get; set; }
    }

    public class Ohlcv
    {
        [JsonProperty("open")]
        public double? Open { get; set; }

        [JsonProperty("high")]
        public double? High { get; set; }

        [JsonProperty("low")]
        public double? Low { get; set; }

        [JsonProperty("close")]
        public double? Close { get; set; }

        [JsonProperty("volume")]
        public long? Volume { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset? Timestamp { get; set; }
    }
}
