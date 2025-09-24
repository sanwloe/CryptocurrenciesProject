using DataModels.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceProvider.Helpers
{
    public static class TimeHelper
    {
        public static (DateTime Start, DateTime End) Calc(DateTime? start, DateTime? end, TimeInterval timeInterval)
        {
            var timeFrame = (int)timeInterval / 60; // інтервал в хвилинах
            if (end != null)
            {
                return new(end.Value - TimeSpan.FromMinutes(timeFrame * 1499), end.Value);
            }
            else if (start != null) 
            {
                return new(start.Value, start.Value + TimeSpan.FromMinutes(timeFrame * 1499));
            }
            throw new ArgumentNullException($"{nameof(start)} or {nameof(end)} must be exist.");
        }
    }
}
