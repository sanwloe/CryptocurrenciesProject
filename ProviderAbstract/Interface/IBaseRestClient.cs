using CryptoCurrencies.Common.Model;
using DataModels.Enums;
using DataModels.Models;
using ProviderAbstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Interface
{
    public interface IBaseRestClient
    {
        Task<RequestResult<IEnumerable<SymbolData>>> GetSymbols();
        Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbol(string symbol);
        Task<RequestResult<IEnumerable<CandleStickData>>> GetCandleStickChartData(string symbol,TimeInterval interval,DateTime? start,DateTime? end);
    }
}
