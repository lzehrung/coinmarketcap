using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCap.Models;
using CoinMarketCap.Models.Cryptocurrency;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace CoinMarketCap
{
    public class CoinMarketCapClient
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://pro-api.coinmarketcap.com/v1/")
        };

        public CoinMarketCapClient(string apiKey)
        {
            _client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate,gzip");
        }

        public async Task<Response<IEnumerable<IdMap>>> GetCryptocurrencyIdMap(IdMapParameters request)
        {
            return await SendApiRequest<IEnumerable<IdMap>>(request, "cryptocurrency/map");
        }

        public async Task<Response<IEnumerable<Metadata>>> GetCryptocurrencyInfo(MetadataParameters request)
        {
            return await SendApiRequest<IEnumerable<Metadata>>(request, "cryptocurrency/info");
        }

        public async Task<Response<IEnumerable<CryptocurrencyWithLatestQuote>>> GetLatestMarketData(ListingLatestParameters request)
        {
            return await SendApiRequest<IEnumerable<CryptocurrencyWithLatestQuote>>(request, "cryptocurrency/listings/latest");
        }

        public async Task<Response<IEnumerable<CryptocurrencyWithHistoricalQuote>>> GetHistoricalMarketData(ListingHistoricalParameters request)
        {
            return await SendApiRequest<IEnumerable<CryptocurrencyWithHistoricalQuote>>(request, "cryptocurrency/listings/historical");
        }

        public async Task<Response<MarketPairLatestResponse>> GetMarketPairLatest(MarketPairsLatestParams request)
        {
            return await SendApiRequest<MarketPairLatestResponse>(request, "cryptocurrency/market-pairs/latest");
        }

        public async Task<Response<OhlcvHistoricalResponse>> GetMarketPairLatest(OhlcvHistoricalParams request)
        {
            return await SendApiRequest<OhlcvHistoricalResponse>(request, "cryptocurrency/ohlcv/historical");
        }

        public async Task<Response<CryptocurrencyWithLatestQuote>> GetLatestQuote(LatestQuoteParams request)
        {
            return await SendApiRequest<CryptocurrencyWithLatestQuote>(request, "cryptocurrency/quotes/latest");
        }

        public async Task<Response<CryptocurrencyWithHistoricalQuote>> GetHistoricalQuote(HistoricalQuoteParams request)
        {
            return await SendApiRequest<CryptocurrencyWithHistoricalQuote>(request, "cryptocurrency/quotes/historical");
        }

        private async Task<Response<T>> SendApiRequest<T>(object requestParams, string endpoint)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestParams), Encoding.UTF8)
            };
            var responseMessage = await _client.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();
            var content = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<T>>(content);
        }
    }
}
