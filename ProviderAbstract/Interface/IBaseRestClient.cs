using CryptoCurrencies.Common.Model;
using DataModels.Enums;
using DataModels.Models;
using ProviderAbstract.Classes;

namespace ProviderAbstract.Interface
{
    public interface IBaseRestClient
    {
        Task<RequestResult<IEnumerable<SymbolData>>> GetSymbolsAsync();
        Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbolAsync(string symbol);
        Task<RequestResult<IEnumerable<CandleStickData>>> GetCandleStickChartDataAsync(string symbol,TimeInterval interval,DateTime? start,DateTime? end);
    }
}
