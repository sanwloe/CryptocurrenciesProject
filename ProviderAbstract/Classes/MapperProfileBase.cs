using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Classes
{
    public abstract class MapperProfileBase : Profile
    {
        protected MapperProfileBase()
        {
            CreateMap<decimal, decimal>().ReverseMap().ConvertUsing(v => NormalizeDecimal(v));
            CreateMap<string, int>().ConvertUsing(v => Convert.ToInt32(v));
            CreateMap<long, DateTime>().ConvertUsing(v => GetTimeFromUnix(v));
        }
        private decimal NormalizeDecimal(decimal value)
        {
            return value / 1.000000000000000000000000m;
        }
        private DateTime GetTimeFromUnix(long milliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).LocalDateTime;
        }
    }
}
