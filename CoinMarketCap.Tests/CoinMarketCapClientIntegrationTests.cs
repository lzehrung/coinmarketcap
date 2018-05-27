using System.Linq;
using System.Threading.Tasks;
using CoinMarketCap.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinMarketCap.Tests
{
    [TestClass]
    public class CoinMarketCapClientIntegrationTests
    {
        private CoinMarketCapClient _client;

        [TestInitialize]
        public void Init()
        {
            _client = new CoinMarketCapClient();
        }

        [TestMethod]
        public async Task GivenGetListings_Request_Succeeds()
        {
            var listingsResponse = await _client.GetListings();

            Assert.IsNotNull(listingsResponse);
        }

        [TestMethod]
        public async Task GivenGetTickers_Request_Succeeds()
        {
            var tickersResponse = await _client.GetTickers();

            Assert.IsNotNull(tickersResponse);
        }

        [TestMethod]
        public async Task GivenGetTickersWithParams_Request_Succeeds()
        {
            var tickersResponse = await _client.GetTickers(101, 50, Sort.Percent_Change_24h, Currency.ETH);

            Assert.IsNotNull(tickersResponse);

            var responseData = tickersResponse.Data.Values.ToArray();
            Assert.AreEqual(50, responseData.Length);

            var first = responseData.FirstOrDefault();
            Assert.IsNotNull(first);

            if (first != null)
            {
                var previousTickerQuote = first.Quotes[Currency.ETH];
                for (var i = 1; i < responseData.Length; i++)
                {
                    var quote = responseData[i].Quotes[Currency.ETH];
                    Assert.IsTrue(previousTickerQuote.PercentChange24H >= quote.PercentChange24H, "Unexpected ticker list sort order.");
                    previousTickerQuote = quote;
                }
            }

        }

        [TestMethod]
        public async Task GivenGetTicker_Request_Succeeds()
        {
            var tickerResponse = await _client.GetTicker(Cryptocurrency.ChainLink);

            Assert.IsNotNull(tickerResponse);
        }

        [TestMethod]
        public async Task GivenGetGlobal_Request_Succeeds()
        {
            var globalResponse = await _client.GetGlobal();

            Assert.IsNotNull(globalResponse);
        }
    }
}
