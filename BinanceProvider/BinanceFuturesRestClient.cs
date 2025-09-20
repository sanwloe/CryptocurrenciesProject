using DataModels.Models;
using ProviderAbstract.Classes;
using ProviderAbstract.Interface;
using Mapper;
using ProviderAbstract.Helpers;

namespace BinanceProvider
{
    public class BinanceFuturesRestClient : IBaseRestClient
    {
        private const string BaseAdress = "https://fapi.binance.com";
        private const string SymbolsEndPoint = "/fapi/v1/ticker/24hr";

        private readonly HttpClient _httpClient;

        public BinanceFuturesRestClient()
        {
            _httpClient = new();
            //_httpClient.BaseAddress = new Uri(BaseAdress);
        }
        public async Task<RequestResult<IEnumerable<SymbolData>>> GetSymbols()
        {
            var response = await _httpClient.GetAsync(Path.Combine(BaseAdress,SymbolsEndPoint));
            var data = await RequestHelper.GetResultFromResponse<IEnumerable<BinanceFuturesTicker>>(response);
            var result = Mapper.Mapper.Instance.Map<IEnumerable<SymbolData>>(data.Result);
            var clone = RequestHelper.CloneWithNewResult(data, result);
            if (clone.IsSuccess) 
            {
                DataHelper.SetExchangeType(clone.Result,DataModels.Enums.ExchangeType.BinanceFutures);
            }
            return clone;
        }
        public Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbol(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}