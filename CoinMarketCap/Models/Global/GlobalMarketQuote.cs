using Newtonsoft.Json;
using System;

namespace CoinMarketCap.Models.Global
{
    public class GlobalMarketQuote
    {
        [JsonProperty("total_market_cap")]
        public long TotalMarketCap { get; set; }

        [JsonProperty("total_volume_24h")]
        public long TotalVolume24H { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
