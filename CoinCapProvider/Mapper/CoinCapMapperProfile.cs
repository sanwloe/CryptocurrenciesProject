using CoinCapProvider.Model;
using CryptoCurrencies.Common.Model;
using DataModels.Models;
using ProviderAbstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
