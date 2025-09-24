using CryptoCurrencies.Common.Data;
using DataModels.Enums;
using System.Collections.ObjectModel;
using DXEnums = DevExpress.Xpf.Charts;

namespace CryptoCurrencies.Common.Helpers
{
    internal static class ChartIntervalHelper
    {
        internal static ReadOnlyCollection<ChartInterval> GetDefaultIntervals()
        {
            return new(
                [
                 new ChartInterval() { Interval = TimeInterval.OneMinute ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Minute,MeasureUnitMultiplier = 1, Description = "1m"},
                 new ChartInterval() { Interval = TimeInterval.FiveMinutes ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Minute,MeasureUnitMultiplier = 5, Description = "5m"},
                 new ChartInterval() { Interval = TimeInterval.FifteenMinutes ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Minute,MeasureUnitMultiplier = 15, Description = "15m"},
                 new ChartInterval() { Interval = TimeInterval.ThirtyMinutes ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Minute,MeasureUnitMultiplier = 30, Description = "30m"},
                 new ChartInterval() { Interval = TimeInterval.OneHour ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Hour,MeasureUnitMultiplier = 1, Description = "1h"},
                 new ChartInterval() { Interval = TimeInterval.SixHours ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Hour,MeasureUnitMultiplier = 6, Description = "6h"},
                 new ChartInterval() { Interval = TimeInterval.TwelveHours ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Hour,MeasureUnitMultiplier = 12, Description = "12h"},
                 new ChartInterval() { Interval = TimeInterval.OneDay ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Day,MeasureUnitMultiplier = 1, Description = "1d"},
                 new ChartInterval() { Interval = TimeInterval.OneWeek ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Week,MeasureUnitMultiplier = 1, Description = "1w"},
                 new ChartInterval() { Interval = TimeInterval.OneMonth ,MeasureUnit = DXEnums.DateTimeMeasureUnit.Month,MeasureUnitMultiplier = 1, Description = "1M"},
            ]);
        }
    }
}
