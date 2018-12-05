using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class MarketPairLatestResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("num_market_pairs")]
        public long? NumMarketPairs { get; set; }

        [JsonProperty("market_pairs")]
        public MarketPair[] MarketPairs { get; set; }
    }

    public class MarketPair
    {
        [JsonProperty("exchange")]
        public Exchange Exchange { get; set; }

        [JsonProperty("market_pair")]
        public string Name { get; set; }

        [JsonProperty("market_pair_base")]
        public MarketPairMetadata MarketPairMetadata { get; set; }

        [JsonProperty("market_pair_quote")]
        public MarketPairMetadata MarketPairQuote { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, object> Quote { get; set; }

        public ExchangeReported ExchangeReported()
        {
            if (Quote.ContainsKey("exchange_reported"))
            {
                return (ExchangeReported)Quote["exchange_reported"];
            }
            return null;
        }

        public QuoteInCurrency GetCurrencyQuote(string currency)
        {
            if (Quote.ContainsKey(currency))
            {
                return (QuoteInCurrency)Quote[currency];
            }
            return null;
        }

        public QuoteInCurrency FirstCurrencyQuote()
        {
            if (Quote.Count >= 1)
            {
                var array = Quote.Values.ToArray();
                return (QuoteInCurrency)array[1];
            }

            return null;
        }
    }

    public class Exchange
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class MarketPairMetadata
    {
        [JsonProperty("currency_id")]
        public long CurrencyId { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currency_type")]
        public string CurrencyType { get; set; }
    }

    public class ExchangeReported
    {
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("volume_24h_base")]
        public double? Volume24HBase { get; set; }

        [JsonProperty("volume_24h_quote")]
        public double? Volume24HQuote { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }

    public class QuoteInCurrency
    {
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("volume_24h")]
        public double? Volume24H { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
