using BinanceProvider.RestApi;
using CryptoCurrencies.Common.Model;
using DataModels.Enums;
using DataModels.Models;
using ProviderAbstract.Classes;
using ProviderAbstract.Interface;

namespace BinanceProvider.Providers
{
    public class BinanceFuturesProvider : ProviderBase,IBaseRestClient
    {
        private readonly IBaseRestClient _restClient;
        public BinanceFuturesProvider()
        {
            _restClient = new BinanceFuturesRestClient();
        }
        public Task<RequestResult<IEnumerable<CandleStickData>>> GetCandleStickChartDataAsync(string symbol, TimeInterval interval, DateTime? start, DateTime? end)
        {
            return _restClient.GetCandleStickChartDataAsync(symbol, interval, start, end);
        }

        public Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbolAsync(string symbol)
        {
            return _restClient.GetMarketsBySymbolAsync(symbol);
        }

        public async Task<RequestResult<IEnumerable<SymbolData>>> GetSymbolsAsync()
        {
            var result = await TryUseCache(_restClient.GetSymbolsAsync());
            return result;
        }
    }
}
