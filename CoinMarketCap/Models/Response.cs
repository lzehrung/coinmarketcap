using Newtonsoft.Json;

namespace CoinMarketCap.Models
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
