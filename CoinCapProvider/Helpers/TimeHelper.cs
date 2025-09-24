using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapProvider.Helpers
{
    internal class TimeHelper
    {
        public static (DateTime Start,DateTime End) Calc(DateTime? start, DateTime? end,TimeInterval timeInterval)
        {
            if (!end.HasValue)
            {
                end = DateTime.Now;
            }
            if (!start.HasValue)
            {
                var timeFrameValue = (double)timeInterval;
                start = GetStartTimeFromTime(end.Value, timeInterval);
            }
            return new(start.Value, end.Value);
        }
        private static DateTime GetStartTimeFromTime(DateTime time, TimeInterval timeInterval)
        {
            var timeFrameValue = (double)timeInterval;
            // API може зависнути , або отримати помилку
            // Тому вираховуємо допустимі проміжки часу на один запит для таймфреймів
            var timeStart = DateTime.Now;
            // Якщо будемо загружати данні для тайм фреймів для таких проміжків часу
            // 1 день
            if ((double)DataModels.Enums.TimeInterval.OneMinute == timeFrameValue)
            {
                return time - TimeSpan.FromDays(1);
            }
            // 4 дні
            if ((double)DataModels.Enums.TimeInterval.OneHour > timeFrameValue)
            {
                return time - TimeSpan.FromDays(4);
            }
            // 1 місяць (Максимальний допустимий інтервал між start i end)
            else
            {
                return time - TimeSpan.FromDays(30);
            }
        }
    }
}
