using Newtonsoft.Json;
using System;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public partial class MarketPairLatest
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("num_market_pairs")]
        public long NumMarketPairs { get; set; }

        [JsonProperty("market_pairs")]
        public MarketPair[] MarketPairs { get; set; }
    }

    public partial class MarketPair
    {
        [JsonProperty("exchange")]
        public Exchange Exchange { get; set; }

        [JsonProperty("market_pair")]
        public string MarketPairMarketPair { get; set; }

        [JsonProperty("market_pair_base")]
        public MarketPairBaseClass MarketPairBase { get; set; }

        [JsonProperty("market_pair_quote")]
        public MarketPairBaseClass MarketPairQuote { get; set; }

        [JsonProperty("quote")]
        public MarketPairQuote Quote { get; set; }
    }

    public partial class Exchange
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public partial class MarketPairBaseClass
    {
        [JsonProperty("currency_id")]
        public long CurrencyId { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currency_type")]
        public string CurrencyType { get; set; }
    }

    public partial class MarketPairQuote
    {
        [JsonProperty("exchange_reported")]
        public ExchangeReported ExchangeReported { get; set; }

        [JsonProperty("USD")]
        public FiatValue Usd { get; set; }
    }

    public partial class ExchangeReported
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h_base")]
        public double Volume24HBase { get; set; }

        [JsonProperty("volume_24h_quote")]
        public double Volume24HQuote { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }

    public partial class FiatValue
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24H { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public long Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public long CreditCount { get; set; }
    }
}
