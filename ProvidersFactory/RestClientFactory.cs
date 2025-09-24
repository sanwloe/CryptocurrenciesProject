using BinanceProvider.RestApi;
using CoinCapProvider.RestApi;
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
                //ExchangeType.CoinMarketCap => new CoinMarketCapRestClient(),
                ExchangeType.CoinCap => new CoinCapRestClient(),
                ExchangeType.BinanceFutures => new BinanceFuturesRestClient(),
                _ => throw new Exception()
            };
        }
    }
}
