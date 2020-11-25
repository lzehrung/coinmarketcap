using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class ListingLatestParameters
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Optionally calculate market quotes in up to 120 currencies at once
        /// by passing a comma-separated list of cryptocurrency or fiat currency symbols.
        /// Each additional convert option beyond the first requires an additional call credit.
        /// A list of supported fiat options can be found here.
        /// Each conversion is returned in its own "quote" object.
        /// </summary>
        [JsonProperty("convert")]
        public string Convert { get; set; }

        /// <summary>
        /// What field to sort the list of cryptocurrencies by.
        /// Default: "market_cap"
        /// Valid values: "name","symbol","date_added","market_cap","market_cap_strict","price","circulating_supply","total_supply","max_supply","num_market_pairs","volume_24h","percent_change_1h","percent_change_24h","percent_change_7d","market_cap_by_total_supply_strict","volume_7d","volume_30d"
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// The direction in which to order cryptocurrencies against the specified sort.
        /// Valid values: "asc","desc"
        /// </summary>
        [JsonProperty("sort_dir")]
        public string SortDir { get; set; }

        /// <summary>
        /// The type of cryptocurrency to include
        /// Valid values: "all","coins","tokens"
        /// </summary>
        [JsonProperty("cryptocurrency_type")]
        public string CryptocurrencyType { get; set; }
    }
}
