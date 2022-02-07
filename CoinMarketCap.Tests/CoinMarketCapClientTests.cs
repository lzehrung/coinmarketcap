using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoinMarketCap.Models;
using CoinMarketCap.Models.Cryptocurrency;
using CoinMarketCap.Tests.Properties;
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
            _client = new CoinMarketCapClient(Settings.Default.cmc_api_key);
        }

        void CheckResponse<T>(Response<T> response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.Status.ErrorCode, response.Status.ErrorMessage);
        }
        void CheckResponse<T>(Response<List<T>> response)
        {
            CheckResponse<List<T>>(response);
            Assert.IsTrue(response.Data.Count > 0);
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
            CheckResponse(response);
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
            CheckResponse(response);
        }

        [TestMethod]
        public async Task GetLatestListingAsync_GivenRequestWithFilter_Succeeds()
        {
            Response<List<CryptocurrencyWithLatestQuote>> response = null;
            int limit = 3;
            response = await _client.GetLatestListingsAsync(new ListingLatestParameters { Limit = limit, CryptocurrencyType = "tokens"/*, Convert = "USD;BTC;ETH"*/}, CancellationToken.None);
            CheckResponse(response);

            Assert.AreEqual(limit, response.Data.Count);
            var d = response.Data.Select(o => o.Symbol);
            Assert.IsFalse(d.Contains("BTC"));
            Assert.IsTrue(d.Contains("USDT"));
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
            CheckResponse(response);
        }

        [TestMethod]
        public async Task GetHystoricalQuoteAsync()
        {
            Response<CryptocurrencyWithHistoricalQuote> response = null;
            response = await _client.GetHistoricalQuoteAsync(new HistoricalQuoteParameters { Id = "1975" }, CancellationToken.None);
            Assert.IsNotNull(response);
            //CheckResponse(response);
            //There is an error because historical data need paid account
            Assert.AreEqual(1006, response.Status.ErrorCode, response.Status.ErrorMessage);
        }
    }
}
