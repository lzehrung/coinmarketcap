using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable PartialTypeWithSinglePart

namespace CoinMarketCap.Models
{
    public partial class GlobalResponse
    {
        [JsonProperty("data")]
        public Global Global { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public partial class Global
    {
        [JsonProperty("active_cryptocurrencies")]
        public long ActiveCryptocurrencies { get; set; }

        [JsonProperty("active_markets")]
        public long ActiveMarkets { get; set; }

        [JsonProperty("bitcoin_percentage_of_market_cap")]
        public double BitcoinPercentageOfMarketCap { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, GlobalQuote> Quotes { get; set; }

        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; }
    }

    public partial class GlobalQuote
    {
        [JsonProperty("total_market_cap")]
        public long TotalMarketCap { get; set; }

        [JsonProperty("total_volume_24h")]
        public long TotalVolume24H { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
}
