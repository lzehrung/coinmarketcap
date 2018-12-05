# CoinMarketCap API Client

A simple [CoinMarketCap Pro API v1](https://pro.coinmarketcap.com/api/v1) client written in C#.

Install with NuGet:
```
Install-Package CoinMarketCap-API
```

[![Build Status](https://travis-ci.org/lzehrung/coinmarketcap.svg?branch=master)](https://travis-ci.org/lzehrung/coinmarketcap)

Currently supports the following endpoints:
- cryptocurrency/info - Get metadata
- cryptocurrency/map - Get CoinMarketCap ID map
- cryptocurrency/listings/latest - List all cryptocurrencies (latest)
- cryptocurrency/listings/historical - List all cryptocurrencies (historical)
- cryptocurrency/market-pairs/latest - Get market pairs (latest)
- cryptocurrency/ohlcv/historical - Get OHLCV values (historical)
- cryptocurrency/quotes/latest - Get market quotes (latest)
- cryptocurrency/quotes/historical - Get market quotes (historical)
- global-metrics/quotes/historical - Get aggregate market metrics (historical)

## Examples
Get CoinMarketCap ID to symbol map for Chainlink:
```cs
var client = new CoinMarketCapClient(yourCmcApiKey);
var listingsResponse = await _client.GetCryptocurrencyIdMapAsync(new IdMapParameters { Symbol = "LINK" }, CancellationToken.None);
```

Example response (JSON):
```cs
{
    "status": {
        "timestamp": "2018-12-05T01:36:35.604Z",
        "error_code": 0,
        "error_message": null,
        "elapsed": 4,
        "credit_count": 1
    },
    "data": [
        {
            "id": 1975,
            "name": "Chainlink",
            "symbol": "LINK",
            "slug": "chainlink",
            "is_active": 1,
            "first_historical_data": "2017-09-20T20:54:59.000Z",
            "last_historical_data": "2018-12-05T01:34:13.000Z"
        }
    ]
}
```

Now we know that Chainlink (LINK) = ID# 1975 on CMC's API.

Get latest quote for Chainlink using CMC ID:
```cs
var client = new CoinMarketCapClient(yourCmcApiKey);
var response = await _client.GetLatestQuoteAsync(new LatestQuoteParameters { Id = 1975 }, CancellationToken.None);
```
Sample response:
```js
{
    "status": {
        "timestamp": "2018-12-05T01:40:40.183Z",
        "error_code": 0,
        "error_message": null,
        "elapsed": 4,
        "credit_count": 1
    },
    "data": {
        "1975": {
            "id": 1975,
            "name": "Chainlink",
            "symbol": "LINK",
            "slug": "chainlink",
            "circulating_supply": 350000000,
            "total_supply": 1000000000,
            "max_supply": null,
            "date_added": "2017-09-20T00:00:00.000Z",
            "num_market_pairs": 22,
            "tags": [],
            "cmc_rank": 49,
            "last_updated": "2018-12-05T01:40:12.000Z",
            "quote": {
                "USD": {
                    "price": 0.281304235668,
                    "volume_24h": 1992511.77392352,
                    "percent_change_1h": -1.82593,
                    "percent_change_24h": -4.31341,
                    "percent_change_7d": -4.89436,
                    "market_cap": 98456482.4838,
                    "last_updated": "2018-12-05T01:40:12.000Z"
                }
            }
        }
    }
}
```

Target Framework
> .NET Standard 1.1

Dependencies
> Newtonsoft.Json 11.0.2
