using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCap.Models;
using CoinMarketCap.Models.Cryptocurrency;
using CoinMarketCap.Models.Global;
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

        public async Task<Response<IEnumerable<IdMap>>> GetCryptocurrencyIdMapAsync(IdMapParameters request)
        {
            return await SendApiRequest<IEnumerable<IdMap>>(request, "cryptocurrency/map");
        }

        public Response<IEnumerable<IdMap>> GetCryptocurrencyIdMap(IdMapParameters request)
        {
            return GetCryptocurrencyIdMapAsync(request).Result;
        }

        public async Task<Response<IEnumerable<Metadata>>> GetCryptocurrencyInfoAsync(MetadataParameters request)
        {
            return await SendApiRequest<IEnumerable<Metadata>>(request, "cryptocurrency/info");
        }

        public Response<IEnumerable<Metadata>> GetCryptocurrencyInfo(MetadataParameters request)
        {
            return GetCryptocurrencyInfoAsync(request).Result;
        }

        public async Task<Response<IEnumerable<CryptocurrencyWithLatestQuote>>> GetLatestMarketDataAsync(ListingLatestParameters request)
        {
            return await SendApiRequest<IEnumerable<CryptocurrencyWithLatestQuote>>(request, "cryptocurrency/listings/latest");
        }

        public Response<IEnumerable<CryptocurrencyWithLatestQuote>> GetLatestMarketData(ListingLatestParameters request)
        {
            return GetLatestMarketDataAsync(request).Result;
        }

        public async Task<Response<IEnumerable<CryptocurrencyWithHistoricalQuote>>> GetHistoricalMarketDataAsync(ListingHistoricalParameters request)
        {
            return await SendApiRequest<IEnumerable<CryptocurrencyWithHistoricalQuote>>(request, "cryptocurrency/listings/historical");
        }

        public Response<IEnumerable<CryptocurrencyWithHistoricalQuote>> GetHistoricalMarketData(ListingHistoricalParameters request)
        {
            return GetHistoricalMarketDataAsync(request).Result;
        }

        public async Task<Response<MarketPairLatestResponse>> GetMarketPairLatestAsync(MarketPairsLatestParams request)
        {
            return await SendApiRequest<MarketPairLatestResponse>(request, "cryptocurrency/market-pairs/latest");
        }

        public Response<MarketPairLatestResponse> GetMarketPairLatest(MarketPairsLatestParams request)
        {
            return GetMarketPairLatestAsync(request).Result;
        }

        public async Task<Response<OhlcvHistoricalResponse>> GetMarketPairLatestAsync(OhlcvHistoricalParams request)
        {
            return await SendApiRequest<OhlcvHistoricalResponse>(request, "cryptocurrency/ohlcv/historical");
        }

        public Response<OhlcvHistoricalResponse> GetMarketPairLatest(OhlcvHistoricalParams request)
        {
            return GetMarketPairLatestAsync(request).Result;
        }

        public async Task<Response<CryptocurrencyWithLatestQuote>> GetLatestQuoteAsync(LatestQuoteParams request)
        {
            return await SendApiRequest<CryptocurrencyWithLatestQuote>(request, "cryptocurrency/quotes/latest");
        }

        public Response<CryptocurrencyWithLatestQuote> GetLatestQuote(LatestQuoteParams request)
        {
            return GetLatestQuoteAsync(request).Result;
        }

        public async Task<Response<CryptocurrencyWithHistoricalQuote>> GetHistoricalQuoteAsync(HistoricalQuoteParams request)
        {
            return await SendApiRequest<CryptocurrencyWithHistoricalQuote>(request, "cryptocurrency/quotes/historical");
        }

        public Response<CryptocurrencyWithHistoricalQuote> GetHistoricalQuote(HistoricalQuoteParams request)
        {
            return GetHistoricalQuoteAsync(request).Result;
        }

        public async Task<Response<AggregateMarketMetrics>> GetAggregateMarketMetricsAsync(AggregateMarketMetricsParams request)
        {
            return await SendApiRequest<AggregateMarketMetrics>(request, "global-metrics/quotes/latest");
        }

        public Response<AggregateMarketMetrics> GetAggregateMarketMetrics(AggregateMarketMetricsParams request)
        {
            return GetAggregateMarketMetricsAsync(request).Result;
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
