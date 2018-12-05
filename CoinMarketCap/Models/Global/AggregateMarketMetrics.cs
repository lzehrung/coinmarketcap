using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Global
{
    public class AggregateMarketMetrics
    {
        [JsonProperty("btc_dominance")]
        public decimal BtcDominance { get; set; }

        [JsonProperty("eth_dominance")]
        public decimal EthDominance { get; set; }

        [JsonProperty("active_cryptocurrencies")]
        public int ActiveCryptocurrencies { get; set; }

        [JsonProperty("active_market_pairs")]
        public int ActiveMarketPairs { get; set; }

        [JsonProperty("active_exchanges")]
        public int ActiveExchanges { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
        
        [JsonProperty("quote")]
        public Dictionary<string, GlobalMarketQuote> Quote { get; set; }
    }
}
