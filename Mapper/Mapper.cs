using AutoMapper;
using AutoMapper.Internal;
using DataModels.Models;

namespace Mapper
{
    public static class Mapper
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration((cfg) =>
            {
                 cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapperProfile>();
            });

            return config.CreateMapper();
        });
        public static IMapper Instance => _mapper.Value;
    }
    internal class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<decimal,decimal>().ReverseMap().ConvertUsing(v => NormalizeDecimal(v));
            CreateMap<string, int>().ConvertUsing(v => Convert.ToInt32(v));
            CreateMap<BinanceFuturesTicker, SymbolData>();
            CreateMap<CoinCapSymbolData, SymbolData>();
        }
        private decimal NormalizeDecimal(decimal value)
        {
            return value / 1.000000000000000000000000m;
        }
    }
}
