using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class MapParameters
    {
        [JsonProperty("listing_status")]
        public string ListingStatus { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
