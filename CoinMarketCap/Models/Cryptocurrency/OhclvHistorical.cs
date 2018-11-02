using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public partial class OhclvHistorical
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quotes")]
        public QuoteElement[] Quotes { get; set; }
    }

    public partial class QuoteElement
    {
        [JsonProperty("time_open")]
        public DateTimeOffset TimeOpen { get; set; }

        [JsonProperty("time_close")]
        public DateTimeOffset TimeClose { get; set; }

        [JsonProperty("quote")]
        public QuoteQuote Quote { get; set; }
    }

    public partial class QuoteQuote
    {
        [JsonProperty("USD")]
        public Usd Usd { get; set; }
    }

    public partial class Usd
    {
        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
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
