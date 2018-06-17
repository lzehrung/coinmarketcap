using System.Linq;
using System.Threading.Tasks;
using CoinMarketCap;
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
            var listingsResponse = await _client.GetListingsAsync();

            Assert.IsNotNull(listingsResponse);
            Assert.IsTrue(listingsResponse.Data.Length > 1000);
        }

        [TestMethod]
        public async Task GivenGetTickers_Request_Succeeds()
        {
            var tickersResponse = await _client.GetTickersAsync();

            Assert.IsNotNull(tickersResponse);
        }

        [TestMethod]
        public async Task GivenGetTickers_RequestWithParams_Succeeds()
        {
            var tickersResponse = await _client.GetTickersAsync(101, 50, Sort.Percent_Change_24h, Currency.ETH);

            Assert.IsNotNull(tickersResponse);

            var responseData = tickersResponse.Data.Values.ToArray();
            Assert.AreEqual(50, responseData.Length);

            var first = responseData.FirstOrDefault();
            Assert.IsNotNull(first);

            var previousTickerQuote = first.Quotes[Currency.ETH];
            for (var i = 1; i < responseData.Length; i++)
            {
                var quote = responseData[i].Quotes[Currency.ETH];
                Assert.IsTrue(previousTickerQuote.PercentChange24H >= quote.PercentChange24H, "Unexpected ticker list sort order.");
                previousTickerQuote = quote;
            }
        }

        [TestMethod]
        public async Task GivenGetTickers_RequestForPage2SortedById_Succeeds()
        {
            // important to sort by ID here since it's the only guaranteed sort order
            var tickersResponse = await _client.GetTickersAsync(101, Limit.Max, Sort.Id, Currency.USD);

            Assert.IsNotNull(tickersResponse);

            var responseData = tickersResponse.Data.Values.ToArray();
            Assert.AreEqual(100, responseData.Length);

            var first = responseData.FirstOrDefault();
            Assert.IsNotNull(first);

            var previousTicker = responseData[0];
            for (var i = 1; i < responseData.Length; i++)
            {
                var currentTicker = responseData[i];
                Assert.IsTrue(previousTicker.Id <= currentTicker.Id, "Unexpected ticker list sort order.");
                previousTicker = currentTicker;
            }
        }

        [TestMethod]
        public async Task GivenGetTicker_Request_Succeeds()
        {
            var tickerResponse = await _client.GetTickerAsync(Cryptocurrency.ChainLink);

            Assert.IsNotNull(tickerResponse);
            Assert.AreEqual("LINK", tickerResponse.Data.Symbol);
        }

        [TestMethod]
        public async Task GivenGetGlobal_Request_Succeeds()
        {
            var globalResponse = await _client.GetGlobalAsync();

            Assert.IsNotNull(globalResponse);
        }
    }
}
