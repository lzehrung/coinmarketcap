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

        public async Task<TickersResponse> GetTickersAsync(int start = 1, int limit = Limit.Max, string sort = Sort.Id, string convert = Currency.USD)
        {
            return await GetTickersAsync(CancellationToken.None, start, limit, sort, convert);
        }

        public async Task<TickersResponse> GetTickersAsync(CancellationToken cancellationToken, int start = 1, int limit = Limit.Max, string sort = Sort.Id, string convert = Currency.USD)
        {
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;
            var startParam = start >= 1 ? $"start={start}" : null;
            var limitParam = limit >= 1 ? $"limit={limit}" : null;
            var sortParam = string.IsNullOrWhiteSpace(sort) ? $"sort={sort}" : null;

            var url = AppendQueryParams("ticker/", convertParam, startParam, limitParam, sortParam);

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
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;
            var url = AppendQueryParams($"ticker/{id}/", convertParam);
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
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;
            var url = AppendQueryParams("global/", convertParam);
            var response = await _client.GetAsync(
                url,
                cancellationToken);
            var globalResponse = await ParseResponse<GlobalResponse>(response);
            return globalResponse;
        }

        private static string AppendQueryParams(string segment, params string[] parameters)
        {
            var encodedParams = parameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(System.Net.WebUtility.HtmlEncode)
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
