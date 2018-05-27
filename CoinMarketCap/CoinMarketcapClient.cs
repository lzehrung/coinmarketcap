using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CoinMarketCap.Models;
using CoinMarketCap.Options;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace CoinMarketCap
{
    public class CoinMarketCapClient
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.coinmarketcap.com/v2/")
        };

        public async Task<ListingsResponse> GetListingsAsync()
        {
            return await GetListingsAsync(CancellationToken.None);
        }

        public async Task<ListingsResponse> GetListingsAsync(CancellationToken cancellationToken)
        {
            const string url = "listings/";
            var response = await _client.GetAsync(
                url,
                HttpCompletionOption.ResponseContentRead,
                cancellationToken);
            var listingsResponse = await ParseResponse<ListingsResponse>(response);
            return listingsResponse;
        }

        public async Task<TickersResponse> GetTickersAsync(int start = 1, int limit = Limit.Default, string sort = Sort.Rank, string convert = Currency.USD)
        {
            return await GetTickersAsync(CancellationToken.None, start, limit, sort, convert);
        }

        public async Task<TickersResponse> GetTickersAsync(CancellationToken cancellationToken, int start = 1, int limit = Limit.Default, string sort = Sort.Id, string convert = Currency.USD)
        {
            var convertValue = convert != Currency.USD ? $"&convert={convert}" : string.Empty;
            var startValue = start != 1 ? $"&start={convert}" : string.Empty;
            var limitValue = start != Limit.Default ? $"&limit={limit}" : string.Empty;
            var sortValue = sort != Sort.Rank ? $"&sort={sort}" : string.Empty;
            var url = AppendQueryParams("ticker/", convertValue, startValue, limitValue, sortValue);
            var response = await _client.GetAsync(
                url,
                cancellationToken);
            var listingsResponse = await ParseResponse<TickersResponse>(response);
            return listingsResponse;
        }

        public async Task<TickerResponse> GetTickerAsync(int id = 1, string convert = Currency.USD)
        {
            return await GetTickerAsync(CancellationToken.None, id, convert);
        }

        public async Task<TickerResponse> GetTickerAsync(CancellationToken cancellationToken, int id = 1, string convert = Currency.USD)
        {
            var convertValue = !string.IsNullOrEmpty(convert) ? $"?convert={convert}" : string.Empty;
            var url = AppendQueryParams("ticker/", convertValue);
            var response = await _client.GetAsync(
                url,
                cancellationToken);
            var listingsResponse = await ParseResponse<TickerResponse>(response);
            return listingsResponse;
        }

        public async Task<GlobalResponse> GetGlobalAsync(string convert = Currency.USD)
        {
            return await GetGlobalAsync(CancellationToken.None, convert);
        }

        public async Task<GlobalResponse> GetGlobalAsync(CancellationToken cancellationToken, string convert = Currency.USD)
        {
            var convertValue = !string.IsNullOrEmpty(convert) ? $"?convert={convert}" : string.Empty;
            var url = AppendQueryParams("global/", convertValue);
            var response = await _client.GetAsync(
                url,
                cancellationToken);
            var globalResponse = await ParseResponse<GlobalResponse>(response);
            return globalResponse;
        }

        private static string AppendQueryParams(string segment, params string[] parameters)
        {
            return parameters.Length > 0 ? string.Join(string.Empty, new[] {segment, "?"}.Concat(parameters)) : segment;
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
