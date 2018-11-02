using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class Metadata
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("logo")]
        public Uri Logo { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }
    }

    public class Urls
    {
        [JsonProperty("website")]
        public Uri[] Website { get; set; }

        [JsonProperty("explorer")]
        public Uri[] Explorer { get; set; }

        [JsonProperty("source_code")]
        public Uri[] SourceCode { get; set; }

        [JsonProperty("message_board")]
        public Uri[] MessageBoard { get; set; }

        [JsonProperty("chat")]
        public object[] Chat { get; set; }

        [JsonProperty("announcement")]
        public object[] Announcement { get; set; }

        [JsonProperty("reddit")]
        public Uri[] Reddit { get; set; }

        [JsonProperty("twitter")]
        public Uri[] Twitter { get; set; }
    }
}
