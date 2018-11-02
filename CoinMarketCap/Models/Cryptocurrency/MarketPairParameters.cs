using System;
using System.Collections.Generic;
using System.Text;

namespace CoinMarketCap.Models.Cryptocurrency
{
    public class MarketPairParameters
    {
        public long Id { get; set; }
        public string Symbol { get; set; }
        public long Start { get; set; }
        public long Limit { get; set; }
        public string Convert { get; set; }
    }
}
