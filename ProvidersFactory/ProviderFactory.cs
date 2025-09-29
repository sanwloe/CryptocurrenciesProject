using DataModels.Enums;
using ProviderAbstract.Interface;


namespace ProvidersFactory
{
    public class ProviderFactory
    {
        public IBaseRestClient GetProvider(ExchangeType type)
        {
            return type switch
            {
                //ExchangeType.CoinMarketCap => new CoinMarketCapRestClient(),
                ExchangeType.CoinCap => new CoinCapProvider.Providers.CoinCapProvider(),
                ExchangeType.BinanceFutures => new BinanceProvider.Providers.BinanceFuturesProvider(),
                _ => throw new NotImplementedException()
            };
        }
        public Dictionary<ExchangeType, IBaseRestClient> GetAvailableProviders()
        {
            return new Dictionary<ExchangeType, IBaseRestClient>()
            {
                //{ ExchangeType.CoinCap, new CoinCapProvider.Providers.CoinCapProvider() },
                { ExchangeType.BinanceFutures, new BinanceProvider.Providers.BinanceFuturesProvider() },
            };
        }
    }
}
