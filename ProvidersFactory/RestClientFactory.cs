using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinanceProvider;
using CoinMarketCapProvider;
using DataModels.Enums;
using ProviderAbstract.Interface;

namespace ProvidersFactory
{
    public class RestClientFactory
    {
        public IBaseRestClient GetRestClient(ExchangeType type)
        {
            return type switch
            {
                ExchangeType.CoinMarketCap => new CoinMarketCapRestClient(),
                ExchangeType.BinanceFutures => new BinanceFuturesRestClient(),
                _ => throw new Exception()
            };
        }
    }
}
