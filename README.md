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


Get the top 100 cryptocurrency quotes in USD, sorted by market cap (rank):
```cs
var client = new CoinMarketCapClient();
var response = await client.GetTickersAsync(1, Limit.Max, Sort.Rank, Currency.USD);
var cryptoQuotes = response.Data.Select(x =>
{
	var quote = x.Value.Quotes[Currency.USD];
	return new
	{
		x.Value.Rank,
		x.Value.Id,
		x.Value.Name,
		x.Value.Symbol,
		quote.Price,
		quote.MarketCap,
		quote.Volume24H,
		quote.PercentChange1H,
		quote.PercentChange24H,
		quote.PercentChange7D,
	};
});
```
Sample output:

| Rank | Id   | Name                  | Symbol | Price       | MarketCap    | Volume24H  | PercentChange1H | PercentChange24H | PercentChange7D |
| ---- | ---- | --------------------- | ------ | ----------- | ------------ | ---------- | --------------- | ---------------- | --------------- |
| 1    | 1    | Bitcoin               | BTC    | 7498.12     | 128034425490 | 4903930000 | -0.12           | -2.86            | 4.85            |
| 2    | 1027 | Ethereum              | ETH    | 595.18      | 59442918526  | 1883770000 | 0.04            | -4.06            | 13.82           |
| 3    | 52   | Ripple                | XRP    | 0.661905    | 25974162166  | 491971000  | 0.04            | -4.93            | 18.12           |
| 4    | 1831 | Bitcoin Cash          | BCH    | 1111.48     | 19079707361  | 864788000  | 0.21            | -7.04            | 23.81           |
| 5    | 1765 | EOS                   | EOS    | 13.559      | 12150890964  | 1291420000 | 0.03            | -7.18            | 16.48           |
| 6    | 2    | Litecoin              | LTC    | 119.829     | 6810645752   | 295669000  | 0.25            | -4.63            | 6.51            |
| 7    | 2010 | Cardano               | ADA    | 0.213002    | 5522517879   | 112359000  | -0.64           | -6.64            | 19.08           |
| 8    | 512  | Stellar               | XLM    | 0.291827    | 5422172015   | 55032700   | -0.23           | -4.79            | 15.14           |
| 9    | 1720 | IOTA                  | MIOTA  | 1.71809     | 4775483184   | 100864000  | -0.88           | -5.32            | 25.99           |
| 10   | 1958 | TRON                  | TRX    | 0.0590979   | 3885575327   | 212389000  | -0.08           | -4.55            | -1.98           |


Get ChainLink (LINK)'s ticker with quote in USD:
```cs
var client = new CoinMarketCapClient();
var chainlinkTicker = await client.GetTickerAsync(1975, Currency.USD);
```


Get ChainLink (LINK)'s ticker with quote in ETH:
```cs
var client = new CoinMarketCapClient();
var chainlinkTicker = await client.GetTickerAsync(1975, Currency.ETH);
```


Target Framework
> .NET Standard 1.1

Dependencies
> Newtonsoft.Json 11.0.2