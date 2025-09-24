using AutoMapper;
using DataModels.Enums;
using ProviderAbstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Helpers
{
    public static class MapperHelper
    {
        private static Dictionary<ExchangeType, IMapper> Mappers = [];

        public static IMapper GetMapper<TProfile>(ExchangeType exchangeType) where TProfile : MapperProfileBase, new()
        {
            if (Mappers.TryGetValue(exchangeType, out var mapper))
            {
                return mapper;
            }
            else
            {
                var newMapper = new Lazy<IMapper>(() =>
                {
                    var config = new MapperConfiguration((cfg) =>
                    {
                        cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                        cfg.AddProfile<TProfile>();
                    });

                    return config.CreateMapper();
                });

                return Mappers[exchangeType] = newMapper.Value;
            }
        }
    }
}
