using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCap.Models;
using CoinMarketCap.Models.Cryptocurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinMarketCap.Tests
{
    [TestClass]
    public class CoinMarketCapClientTests
    {
        private CoinMarketCapClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _client = new CoinMarketCapClient("your-api-key");
        }

        [TestMethod]
        public async Task GetAggregateMarketMetrics_GivenRequest_Succeeds()
        {
            Response<List<IdMap>> response = null;
            try
            {
                response = await _client.GetCryptocurrencyIdMapAsync(new IdMapParameters());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetListingLatest_GivenRequest_Succeeds()
        {
            Response<List<CryptocurrencyWithLatestQuote>> response = null;
            try
            {
                response = await _client.GetLatestListingsAsync(new ListingLatestParameters());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(response);
        }
    }
}
