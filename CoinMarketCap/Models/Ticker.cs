using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable PartialTypeWithSinglePart

namespace CoinMarketCap.Models
{
    public partial class TickersResponse
    {
        [JsonProperty("data")]
        public Dictionary<string, Ticker> Data { get; set; }

        [JsonProperty("metadata")]
        public TickerMetadata TickerMetadata { get; set; }
    }

    public partial class TickerResponse
    {
        [JsonProperty("data")]
        public Ticker Data { get; set; }

        [JsonProperty("metadata")]
        public TickerMetadata TickerMetadata { get; set; }
    }

    public partial class Ticker
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; }

        [JsonProperty("rank")]
        public long? Rank { get; set; }

        [JsonProperty("circulating_supply")]
        public long? CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public long? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public long? MaxSupply { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, TickerQuote> Quotes { get; set; }

        [JsonProperty("last_updated")]
        public long? LastUpdated { get; set; }
    }

    public partial class TickerQuote
    {
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("volume_24h")]
        public double? Volume24H { get; set; }

        [JsonProperty("market_cap")]
        public long? MarketCap { get; set; }

        [JsonProperty("percent_change_1h")]
        public double? PercentChange1H { get; set; }

        [JsonProperty("percent_change_24h")]
        public double? PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")]
        public double? PercentChange7D { get; set; }
    }

    public partial class TickerMetadata
    {
        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }

        [JsonProperty("num_cryptocurrencies")]
        public long? NumCryptocurrencies { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
}
