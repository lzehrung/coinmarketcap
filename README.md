# CoinMarketCap API Client

A simple [CoinMarketCap API v2](https://coinmarketcap.com/api/) client written in C#.

## Examples
Get all listed cryptocurrencies:
```cs
var client = new CoinMarketCapClient();
var listingsResponse = await client.GetListingsAsync();
```
Get tickers rank 101-200 with quotes in USD:
```cs
var client = new CoinMarketCapClient();
var tickersResponse = await client.GetTickersAsync(101, Limit.Max, Sort.Rank, Currency.USD);
```
Get cryptocurrency ID 1975's (ChainLink) ticker with quote in USD:
```cs
var client = new CoinMarketCapClient();
var chainlinkTicker = await client.GetTickerAsync(1975, Currency.USD);
```

Target Framework
> .NET Standard 1.1

Dependencies
> Newtonsoft.Json 11.0.2