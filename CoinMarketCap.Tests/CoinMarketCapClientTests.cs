using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoinMarketCap.Models;
using CoinMarketCap.Models.Cryptocurrency;
using CoinMarketCap.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinMarketCap.Tests
{
    [Ignore]
    [TestClass]
    public class CoinMarketCapClientTests
    {
        private CoinMarketCapClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _client = new CoinMarketCapClient(Settings.Default.cmc_api_key);
        }

        [TestMethod]
        public async Task GetCryptocurrencyIdMapAsync_GivenRequest_Succeeds()
        {
            Response<List<IdMap>> response = null;
            try
            {
                response = await _client.GetCryptocurrencyIdMapAsync(new IdMapParameters { Symbol = "LINK" }, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetLatestListingsAsync_GivenRequest_Succeeds()
        {
            Response<List<CryptocurrencyWithLatestQuote>> response = null;
            try
            {
                response = await _client.GetLatestListingsAsync(new ListingLatestParameters(), CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetLatestQuoteAsync_GivenRequest_Succeeds()
        {
            Response<Dictionary<string, CryptocurrencyWithLatestQuote>> response = null;
            try
            {
                response = await _client.GetLatestQuoteAsync(new LatestQuoteParameters { Id = 1975 }, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(response);
        }
    }
}
