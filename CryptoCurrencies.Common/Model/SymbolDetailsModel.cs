using CryptoCurrencies.Common.Data;
using CryptoCurrencies.Common.Helpers;
using DataModels.Models;
using System.Collections.ObjectModel;

namespace CryptoCurrencies.Common.Model
{
    public class SymbolDetailsModel : DataModelBase
    {
        public SymbolDetailsModel()
        {
            CandleStickData = [];
            Markets = [];
            Intervals = new(ChartIntervalHelper.GetDefaultIntervals());
            SelectedChartInterval = Intervals[1];
            CanLoadChartData = true;
        }
        public bool CanLoadChartData { get; set; }
        public SymbolData SymbolData { get => GetValue<SymbolData>(); set => SetValue(value); }
        public decimal MinPriceVisualRange { get =>  GetValue<decimal>(); set => SetValue(value); }
        public decimal MaxPriceVisualRange { get => GetValue<decimal>(); set => SetValue(value); }
        public DateTime MinDateTimeVisualRange { get => GetValue<DateTime>(); set => SetValue(value); }
        public DateTime MaxDateTimeVisualRange { get => GetValue<DateTime>(); set => SetValue(value); }
        public ChartInterval SelectedChartInterval { get => GetValue<ChartInterval>(); set => SetValue(value); }
        public ObservableCollection<MarketData> Markets { get => GetValue<ObservableCollection<MarketData>>(); set => SetValue(value); }
        public ObservableCollection<CandleStickData> CandleStickData { get => GetValue<ObservableCollection<CandleStickData>>(); set => SetValue(value); }
        public List<ChartInterval> Intervals { get => GetValue<List<ChartInterval>>(); set => SetValue(value); }
    }
}
