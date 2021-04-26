using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class LatestQuoteParameters
    {
        public int? Id { get; set; }

        public List<int> Ids { get; } = new List<int>();

        [JsonProperty("id")]
        internal string FlattenedIds {
	        get {
		        if(Id.HasValue)
			        return Id.ToString();
		        return Ids.Any() ? string.Join(",", Ids) : null;
	        }
        }

        public string Symbol { get; set; }

        public List<string> Symbols { get; } = new List<string>();

        [JsonProperty("symbol")]
        internal string FlattenedSymbols {
	        get {
		        if(!string.IsNullOrWhiteSpace(Symbol))
			        return Symbol;
                return Symbols.Any() ? string.Join(",", Symbols) : null;
	        }
        }

        [JsonProperty("convert")]
        public string Convert { get; set; }
    }
}
