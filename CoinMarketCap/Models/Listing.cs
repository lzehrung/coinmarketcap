using Newtonsoft.Json;
// ReSharper disable PartialTypeWithSinglePart

namespace CoinMarketCap.Models
{
    public partial class ListingsResponse
    {
        [JsonProperty("data")]
        public Listing[] Data { get; set; }

        [JsonProperty("metadata")]
        public ListingsMetadata ListingsMetadata { get; set; }
    }

    public partial class Listing
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; }
    }

    public partial class ListingsMetadata
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("num_cryptocurrencies")]
        public long NumCryptocurrencies { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
}
