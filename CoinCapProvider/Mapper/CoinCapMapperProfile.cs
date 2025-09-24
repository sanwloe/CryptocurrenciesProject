using CoinCapProvider.Model;
using CryptoCurrencies.Common.Model;
using DataModels.Models;
using ProviderAbstract.Classes;

namespace CoinCapProvider.Mapper
{
    public class CoinCapMapperProfile : MapperProfileBase
    {
        public CoinCapMapperProfile()
        {
            CreateMap<CoinCapSymbolData, SymbolData>();
            CreateMap<CoinCapCandleStickData, CandleStickData>();
        }
    }
}
