using BinanceProvider.Model;
using CryptoCurrencies.Common.Model;
using DataModels.Models;
using ProviderAbstract.Classes;

namespace BinanceProvider.Mapper
{
    public class BinanceFuturesMapperProfile : MapperProfileBase
    {
        public BinanceFuturesMapperProfile()
        {
            CreateMap<BinanceFuturesTicker, SymbolData>();
            CreateMap<BinanceFuturesCandleStickData, CandleStickData>();
        }
    }
}
