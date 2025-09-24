using CommunityToolkit.Mvvm.Input;
using CryptoCurrencies.Common.Data;
using CryptoCurrencies.Common.Helpers;
using CryptoCurrencies.Common.Model;
using DataModels.Enums;
using DataModels.Models;
using DevExpress.Diagram.Core.Shapes;
using DevExpress.Xpf.Charts;
using ProviderAbstract.Interface;
using ProvidersFactory;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CryptoCurrencies.Common.ViewModel
{
    public class SymbolDetailsViewModel : ViewModelBaseT<SymbolDetailsModel>
    {
        private readonly RestClientFactory _restClientFactory;
        private readonly IBaseRestClient _restClient;

        public RelayCommand<MarketData> OpenExchangeCommand { get; set; }
        public AsyncRelayCommand<XYDiagram2DScrollEventArgs> ChartHorizontalScrollCommand { get; set; }
        public RelayCommand<XYDiagram2DZoomEventArgs> ChartZoomCommand { get; set; }
        public SymbolDetailsViewModel(RestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory;
            _restClient = restClientFactory.GetRestClient(DataModels.Enums.ExchangeType.BinanceFutures);

            OpenExchangeCommand = new RelayCommand<MarketData>(TryOpenExchange!);
            ChartHorizontalScrollCommand = new AsyncRelayCommand<XYDiagram2DScrollEventArgs>(ChartHorizontalScroll!);
            ChartZoomCommand = new RelayCommand<XYDiagram2DZoomEventArgs>(ChartZoom!);
        }
        internal protected override async Task ViewLoadedAsync()
        {
            //Model.Markets.Add(new MarketData()
            //{
            //    MarketName = "Binance",
            //    Price = 100000,
            //    PriceCurrency = "USDT"
            //});
            //Model.Markets.Add(new MarketData()
            //{
            //    MarketName = "ByBit",
            //    Price = 100000,
            //    PriceCurrency = "USDT"
            //});

            var candleStickData = GetChartDataAsync(null,DateTime.Now);
            var markets = GetMarketsAsync();
            await Task.WhenAll(candleStickData,markets);
            Model.Markets = new(await markets);
            AddDataToChart(await candleStickData);
        }
        private async Task<IEnumerable<MarketData>> GetMarketsAsync()
        {
            var result = await _restClient.GetMarketsBySymbol(Model.SymbolData.Name);
            if (result.IsSuccess) 
            {
                return result.Result;
            }
            else
            {
                return [];
            }
        }
        // Не всі відкриваються.....
        private void TryOpenExchange(MarketData marketData)
        {
            try
            {
                var uri = new Uri($"https://{marketData.MarketName}.com");
                Process.Start(new ProcessStartInfo()
                {
                    FileName = uri.AbsoluteUri,
                    UseShellExecute = true
                });
            }
            catch
            {
                System.Windows.MessageBox.Show($"Не вдалось відкрити сайт для {marketData.MarketName}");
            }
        }
        private void ChartZoom(XYDiagram2DZoomEventArgs e)
        {
            if (e.OriginalSource is DevExpress.Xpf.Charts.XYDiagram2D d)
            {
                var visibleRangeMin = (DateTime)d.ActualAxisX.ActualVisualRange.ActualMinValue;
                var visibleRangeMax = (DateTime)d.ActualAxisX.ActualVisualRange.ActualMaxValue;

                CalcMaxMinVisualRange(d);
            }
        }
        private async Task ChartHorizontalScroll(XYDiagram2DScrollEventArgs arg)
        {
            if (arg.AxisX != null)
            {
                var visualRangeMin = (DateTime)arg.AxisX.ActualVisualRange.ActualMinValue;
                var wholeRangeMin = (DateTime)arg.AxisX.ActualWholeRange.ActualMinValue;
                if (visualRangeMin <= wholeRangeMin)
                {
                    if(Model.CanLoadChartData)
                    {
                        var timeIntervalValue = (double)Model.SelectedChartInterval.Interval;
                        var data = await GetChartDataAsync(null,wholeRangeMin);
                        AddDataToChart(data);
                    }
                }
                if (arg.OriginalSource is XYDiagram2D d)
                    CalcMaxMinVisualRange(d);
            }
        }
        private void AddDataToChart(IEnumerable<CandleStickData> data)
        {
            if (Model.CandleStickData.Count == 0)
            {
                Model.CandleStickData = new ObservableCollection<CandleStickData>(data.OrderBy(x => x.OpenTime));
                ScrollChartToRightEnd();
            }
            else
            {
                foreach (var item in data.OrderBy(x => x.OpenTime))
                {
                    Model.CandleStickData.Add(item);
                }
            }
        }
        private void CalcMaxMinVisualRange(XYDiagram2D d)
        {
            var visibleRangeMin = (DateTime)d.ActualAxisX.ActualVisualRange.ActualMinValue;
            var visibleRangeMax = (DateTime)d.ActualAxisX.ActualVisualRange.ActualMaxValue;

            decimal? minPrice = null;
            decimal? maxPrice = null;

            foreach (var point in Model.CandleStickData)
            {
                if (point.OpenTime >= visibleRangeMin && point.OpenTime <= visibleRangeMax)
                {
                    if (minPrice == null || point.LowPrice < minPrice)
                        minPrice = point.LowPrice;

                    if (maxPrice == null || point.HighPrice > maxPrice)
                        maxPrice = point.HighPrice;
                }
            }

            if (minPrice != null && maxPrice != null) 
            {
                Model.MinPriceVisualRange = minPrice.Value;
                Model.MaxPriceVisualRange = maxPrice.Value;
            }
        }
        private async Task<IEnumerable<CandleStickData>> GetChartDataAsync(DateTime? start,DateTime? end )
        {
            var result = await _restClient.GetCandleStickChartData(
                Model.SymbolData.Name
                , Model.SelectedChartInterval.Interval
                , start
                , end);

            if(result.IsSuccess)
            {
                return result.Result;
            }
            else
            {
                Model.CanLoadChartData = false;
                System.Windows.MessageBox.Show(result.ErrorMessage, "Error");
                return [];
            }
        }
        private void ScrollChartToRightEnd()
        {
            var count = Model.CandleStickData.Count;
            Model.MaxDateTimeVisualRange = Model.CandleStickData[count - 1].OpenTime;
            Model.MinDateTimeVisualRange = Model.CandleStickData[count - 100].OpenTime;
            Model.MaxPriceVisualRange = Model.CandleStickData[count - 1].HighPrice;
            Model.MinPriceVisualRange = Model.CandleStickData[count - 100].LowPrice;
        }
    }
}
