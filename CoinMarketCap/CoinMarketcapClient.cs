using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
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
        public readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri("https://pro-api.coinmarketcap.com/v1/")
        };

        public CoinMarketCapClient(string apiKey)
        {
            HttpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Returns a paginated list of all cryptocurrencies by CoinMarketCap ID. We recommend using this convenience endpoint to lookup and utilize our unique cryptocurrency id across all endpoints as typical identifiers like ticker symbols can match multiple cryptocurrencies and change over time. As a convenience you may pass a comma-separated list of cryptocurrency symbols as symbol to filter this list to only those you require.
        /// </summary>
        public async Task<Response<List<IdMap>>> GetCryptocurrencyIdMapAsync(IdMapParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<List<IdMap>>(request, "cryptocurrency/map", cancellationToken);
        }

        /// <summary>
        /// Returns a paginated list of all cryptocurrencies by CoinMarketCap ID. We recommend using this convenience endpoint to lookup and utilize our unique cryptocurrency id across all endpoints as typical identifiers like ticker symbols can match multiple cryptocurrencies and change over time. As a convenience you may pass a comma-separated list of cryptocurrency symbols as symbol to filter this list to only those you require.
        /// </summary>
        public Response<List<IdMap>> GetCryptocurrencyIdMap(IdMapParameters request)
        {
            return GetCryptocurrencyIdMapAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Returns all static metadata for one or more cryptocurrencies including name, symbol, logo, and its various registered URLs.
        /// </summary>
        public async Task<Response<List<Metadata>>> GetCryptocurrencyInfoAsync(MetadataParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<List<Metadata>>(request, "cryptocurrency/info", cancellationToken);
        }

        /// <summary>
        /// Returns all static metadata for one or more cryptocurrencies including name, symbol, logo, and its various registered URLs.
        /// </summary>
        public Response<List<Metadata>> GetCryptocurrencyInfo(MetadataParameters request)
        {
            return GetCryptocurrencyInfoAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Get a paginated list of all cryptocurrencies with latest market data. You can configure this call to sort by market cap or another market ranking field. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public async Task<Response<List<CryptocurrencyWithLatestQuote>>> GetLatestListingsAsync(ListingLatestParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<List<CryptocurrencyWithLatestQuote>>(request, "cryptocurrency/listings/latest", cancellationToken);
        }

        /// <summary>
        /// Get a paginated list of all cryptocurrencies with latest market data. You can configure this call to sort by market cap or another market ranking field. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public Response<List<CryptocurrencyWithLatestQuote>> GetLatestListings(ListingLatestParameters request)
        {
            return GetLatestListingsAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Get a paginated list of all cryptocurrencies with market data for a given historical time. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public async Task<Response<List<CryptocurrencyWithHistoricalQuote>>> GetHistoricalListingsAsync(ListingHistoricalParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<List<CryptocurrencyWithHistoricalQuote>>(request, "cryptocurrency/listings/historical", cancellationToken);
        }

        /// <summary>
        /// Get a paginated list of all cryptocurrencies with market data for a given historical time. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public Response<List<CryptocurrencyWithHistoricalQuote>> GetHistoricalListings(ListingHistoricalParameters request)
        {
            return GetHistoricalListingsAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Lists all market pairs for the specified cryptocurrency with associated stats. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public async Task<Response<MarketPairLatestResponse>> GetMarketPairLatestAsync(MarketPairsLatestParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<MarketPairLatestResponse>(request, "cryptocurrency/market-pairs/latest", cancellationToken);
        }

        /// <summary>
        /// Lists all market pairs for the specified cryptocurrency with associated stats. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public Response<MarketPairLatestResponse> GetMarketPairLatest(MarketPairsLatestParameters request)
        {
            return GetMarketPairLatestAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Return an interval of historic OHLCV (Open, High, Low, Close, Volume) market quotes for a cryptocurrency. Currently daily and hourly OHLCV periods are supported.
        /// </summary>
        public async Task<Response<OhlcvHistoricalResponse>> GetOhlcvHistoricalAsync(OhlcvHistoricalParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<OhlcvHistoricalResponse>(request, "cryptocurrency/ohlcv/historical", cancellationToken);
        }

        /// <summary>
        /// Return an interval of historic OHLCV (Open, High, Low, Close, Volume) market quotes for a cryptocurrency. Currently daily and hourly OHLCV periods are supported.
        /// </summary>
        public Response<OhlcvHistoricalResponse> GetOhlcvHistorical(OhlcvHistoricalParameters request)
        {
            return GetOhlcvHistoricalAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Get the latest market quote for 1 or more cryptocurrencies. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public async Task<Response<Dictionary<string,CryptocurrencyWithLatestQuote>>> GetLatestQuoteAsync(LatestQuoteParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<Dictionary<string, CryptocurrencyWithLatestQuote>>(request, "cryptocurrency/quotes/latest", cancellationToken);
        }

        /// <summary>
        /// Get the latest market quote for 1 or more cryptocurrencies. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public Response<Dictionary<string, CryptocurrencyWithLatestQuote>> GetLatestQuote(LatestQuoteParameters request)
        {
            return GetLatestQuoteAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
        /// </summary>
        public async Task<Response<CryptocurrencyWithHistoricalQuote>> GetHistoricalQuoteAsync(HistoricalQuoteParameters request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<CryptocurrencyWithHistoricalQuote>(request, "cryptocurrency/quotes/historical", cancellationToken);
        }

        /// <summary>
        /// Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
        /// </summary>
        public Response<CryptocurrencyWithHistoricalQuote> GetHistoricalQuote(HistoricalQuoteParameters request)
        {
            return GetHistoricalQuoteAsync(request, CancellationToken.None).Result;
        }

        /// <summary>
        /// Get the latest quote of aggregate market metrics. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public async Task<Response<AggregateMarketMetrics>> GetAggregateMarketMetricsAsync(AggregateMarketMetricsParams request, CancellationToken cancellationToken)
        {
            return await SendApiRequest<AggregateMarketMetrics>(request, "global-metrics/quotes/latest", cancellationToken);
        }

        /// <summary>
        /// Get the latest quote of aggregate market metrics. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        public Response<AggregateMarketMetrics> GetAggregateMarketMetrics(AggregateMarketMetricsParams request)
        {
            return GetAggregateMarketMetricsAsync(request, CancellationToken.None).Result;
        }

        private async Task<Response<T>> SendApiRequest<T>(object requestParams, string endpoint, CancellationToken cancellationToken)
        {
            var queryParams = ConvertToQueryParams(requestParams);
            var endpointWithParams = $"{endpoint}{queryParams}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointWithParams);
            var responseMessage = await HttpClient.SendAsync(requestMessage, cancellationToken);
            responseMessage.EnsureSuccessStatusCode();
            var content = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<T>>(content);
        }

        private static string ConvertToQueryParams(object parameters)
        {
            var properties = parameters.GetType().GetRuntimeProperties();
            var encodedValues = properties
                .Select(x => new
                {
                    Name = x.Name.ToLower(),
                    Value = x.GetValue(parameters)
                })
                .Where(x => x.Value != null)
                .Select(x => $"{x.Name}={System.Net.WebUtility.UrlEncode(x.Value.ToString())}")
                // prepend ? for the first param, & for the rest
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}");

            return string.Join(string.Empty, encodedValues);
        }
    }
}
