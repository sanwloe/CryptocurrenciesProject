using DataModels.Models;
using ProviderAbstract.Classes;
using ProviderAbstract.Interface;
using ProviderAbstract.Helpers;
using BinanceProvider.Mapper;
using CryptoCurrencies.Common.Model;
using BinanceProvider.Model;
using BinanceProvider.Helpers;
using DataModels.Enums;
using DataModels.Helpers;

namespace BinanceProvider.RestApi
{
    public class BinanceFuturesRestClient : IBaseRestClient
    {
        private const string BaseAdress = "https://fapi.binance.com/";
        private const string SymbolsEndPoint = "fapi/v1/ticker/24hr";
        private const string CandleStickDataEndPoint = "fapi/v1/klines";

        private readonly HttpClient _httpClient;

        public BinanceFuturesRestClient()
        {
            _httpClient = new();
            _httpClient.BaseAddress = new Uri(BaseAdress);
        }
        public async Task<RequestResult<IEnumerable<SymbolData>>> GetSymbols()
        {
            var response = await _httpClient.GetAsync(SymbolsEndPoint);
            var data = await RequestHelper.GetResultFromResponse<IEnumerable<BinanceFuturesTicker>>(response);
            var mapper = MapperHelper.GetMapper<BinanceFuturesMapperProfile>();
            var mapData = mapper.Map<IEnumerable<SymbolData>>(data.Result);
            var result = RequestHelper.CloneWithNewResult(data, mapData);
            if (result.IsSuccess) 
            {
                DataHelper.SetExchangeType(result.Result,DataModels.Enums.ExchangeType.BinanceFutures);
            }
            return result;
        }
        public Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbol(string symbol)
        {
            return Task.FromResult(new RequestResult<IEnumerable<MarketData>>()
            {
                ErrorMessage = "Don`t available"
            });
        }
        public async Task<RequestResult<IEnumerable<CandleStickData>>> GetCandleStickChartData(string symbol, TimeInterval interval, DateTime? start, DateTime? end)
        {
            var stringInterval = IntervalHelper.GetStringInterval(interval);
            var time = TimeHelper.Calc(start, end,interval);
            var endPoint = RequestHelper.GetEndPointWithParameters(CandleStickDataEndPoint,
                requestParameters : new Dictionary<string, string>()
                {
                    { "symbol", symbol },
                    { "interval", stringInterval },
                    { "startTime", time.Start.GetUnixTimeMs().ToString() },
                    { "endTime", time.End.GetUnixTimeMs().ToString() },
                    { "limit" , 1500.ToString() }
                });
            var response = await _httpClient.GetAsync(endPoint);
            var data = await RequestHelper.GetResultFromResponse<IEnumerable<BinanceFuturesCandleStickData>>(response);
            var mapper = MapperHelper.GetMapper<BinanceFuturesMapperProfile>();
            var mapData = mapper.Map<IEnumerable<CandleStickData>>(data.Result);
            var result = RequestHelper.CloneWithNewResult(data, mapData);
            return result;
        }
    }
}