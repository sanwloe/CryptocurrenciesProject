using DataModels.Enums;

namespace DataModels.Helpers
{
    public static class IntervalHelper
    {
        public static string GetStringInterval(this TimeInterval interval)
        {
            return interval switch
            {
                TimeInterval.OneMinute => TimeFrame.OneMinute,
                TimeInterval.FiveMinutes => TimeFrame.FiveMinutes,
                TimeInterval.FifteenMinutes => TimeFrame.FifteenMinutes,
                TimeInterval.ThirtyMinutes => TimeFrame.ThirtyMinutes,
                TimeInterval.OneHour => TimeFrame.OneHour,
                TimeInterval.SixHours => TimeFrame.SixHours,
                TimeInterval.TwelveHours => TimeFrame.TwelveHours,
                TimeInterval.OneDay => TimeFrame.OneDay,
                TimeInterval.OneWeek => TimeFrame.OneWeek,
                TimeInterval.OneMonth => TimeFrame.OneMonth,
                _ => throw new NotImplementedException(),
            };
        }
        public static TimeInterval GetIntervalFromString(this string interval) 
        {
            return interval switch
            {
                TimeFrame.OneMinute => TimeInterval.OneMinute,
                TimeFrame.FiveMinutes => TimeInterval.FiveMinutes,
                TimeFrame.FifteenMinutes => TimeInterval.FifteenMinutes,
                TimeFrame.ThirtyMinutes => TimeInterval.ThirtyMinutes,
                TimeFrame.OneHour => TimeInterval.OneHour,
                TimeFrame.SixHours => TimeInterval.SixHours,
                TimeFrame.TwelveHours => TimeInterval.TwelveHours,
                TimeFrame.OneDay => TimeInterval.OneDay,
                TimeFrame.OneWeek => TimeInterval.OneWeek,
                TimeFrame.OneMonth => TimeInterval.OneMonth,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
