using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class CryptocurrencyWithHistoricalQuote
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("cmc_rank")]
        public long? CmcRank { get; set; }

        [JsonProperty("num_market_pairs")]
        public long? NumMarketPairs { get; set; }

        [JsonProperty("circulating_supply")]
        public long? CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public long? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public long? MaxSupply { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, CryptocurrencyPriceQuote> Quote { get; set; }
    }
}