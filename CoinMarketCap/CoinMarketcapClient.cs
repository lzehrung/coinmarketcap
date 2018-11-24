using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            // cryptocurrency/map
            return new Response<IEnumerable<IdMap>>();
        }

        public async Task<Response<IEnumerable<Metadata>>> GetCryptocurrencyInfo(MetadataParameters request)
        {
            // cryptocurrency/info
            return new Response<IEnumerable<Metadata>>();
        }

        public async Task<Response<IEnumerable<CryptocurrencyWithLatestQuote>>> GetLatestMarketData(ListingLatestParameters request)
        {
            // cryptocurrency/listings/latest
            return new Response<IEnumerable<CryptocurrencyWithLatestQuote>>();
        }

        public async Task<Response<IEnumerable<CryptocurrencyWithHistoricalQuote>>> GetHistoricalMarketData(ListingHistoricalParameters request)
        {
            // cryptocurrency/listings/historical
            return new Response<IEnumerable<CryptocurrencyWithHistoricalQuote>>();
        }

        public async Task<Response<MarketPairLatestResponse>> GetMarketPairLatest(MarketPairsLatestParams request)
        {
            // cryptocurrency/market-pairs/latest
            return new Response<MarketPairLatestResponse>();
        }
        
        private static string AppendQueryParams(string segment, params string[] parameters)
        {
            var encodedParams = parameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(System.Net.WebUtility.HtmlEncode)
                // prepend ? for the first param, & for the rest
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                .ToArray();

            return encodedParams.Length > 0 ? $"{segment}{string.Join(string.Empty, encodedParams)}" : segment;
        }

        private static async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var listingsResponse = JsonConvert.DeserializeObject<T>(responseContent);
            return listingsResponse;
        }
    }
}
