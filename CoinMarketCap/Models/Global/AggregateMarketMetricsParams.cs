using Newtonsoft.Json;

namespace CoinMarketCap.Models.Global
{
    public class AggregateMarketMetricsParams
    {
        [JsonProperty("convert")]
        public string Convert { get; set; }
    }
}