using DevExpress.Xpf.Charts;

namespace CryptoCurrencies.Common.Data
{
    public class ChartInterval
    {
        public string Description { get; set; } = string.Empty;
        public DataModels.Enums.TimeInterval Interval { get; set; }
        public DateTimeMeasureUnit MeasureUnit { get; set; }
        public int MeasureUnitMultiplier { get; set; } = 1;
    }
}
