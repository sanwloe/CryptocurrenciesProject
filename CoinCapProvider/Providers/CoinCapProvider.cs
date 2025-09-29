using CoinCapProvider.RestApi;
using CryptoCurrencies.Common.Model;
using DataModels.Enums;
using DataModels.Models;
using ProviderAbstract.Classes;
using ProviderAbstract.Interface;

namespace CoinCapProvider.Providers
{
    public class CoinCapProvider : ProviderBase, IBaseRestClient
    {
        private IBaseRestClient _restClient;
        public CoinCapProvider()
        {
            _restClient = new CoinCapRestClient();
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
