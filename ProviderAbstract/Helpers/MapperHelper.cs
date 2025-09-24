using AutoMapper;
using ProviderAbstract.Classes;

namespace ProviderAbstract.Helpers
{
    public static class MapperHelper
    {
        private static Dictionary<string, IMapper> Mappers = [];

        public static IMapper GetMapper<TProfile>() where TProfile : MapperProfileBase, new()
        {
            if (Mappers.TryGetValue(typeof(TProfile).Name, out var mapper))
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

                return Mappers[typeof(TProfile).Name] = newMapper.Value;
            }
        }
    }
}
