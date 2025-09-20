using DataModels.Models;
using ProviderAbstract.Classes;
using ProviderAbstract.Helpers;
using ProviderAbstract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapProvider.RestApi
{
    public class CoinCapRestClient : IBaseRestClient
    {
        private const string BaseAdress = "https://rest.coincap.io/v3/";
        private const string SymbolsEndPoint = "assets";
        private const string ApiKey = "ba67b2a47b2403bb233901b1586be84e3908c285565bc7bc6554ab9f27a73c5a";
        private const string MarketsEndPoint = "assets/{slug}/markets";

        private readonly HttpClient _httpClient;

        public CoinCapRestClient()
        {
            _httpClient = new();
            _httpClient.BaseAddress = new Uri(BaseAdress);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiKey);
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
        }
        public async Task<RequestResult<IEnumerable<SymbolData>>> GetSymbols()
        {
            var response = await _httpClient.GetAsync(SymbolsEndPoint);
            var data = await RequestHelper.GetResultFromResponse<IEnumerable<CoinCapSymbolData>>(response);
            var result = Mapper.Mapper.Instance.Map<IEnumerable<SymbolData>>(data.Result);
            var clone = RequestHelper.CloneWithNewResult(data, result);
            if(clone.IsSuccess)
            {
                DataHelper.SetExchangeType(clone.Result,DataModels.Enums.ExchangeType.CoinCap);
            }
            return clone;
        }
        public async Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbol(string symbol)
        {
            var response = await _httpClient.GetAsync(RequestHelper.GetEndPointWithParameters(MarketsEndPoint,
                new Dictionary<string, string>()
                {
                    { "slug",symbol }
                }));
            var data = await RequestHelper.GetResultFromResponse<IEnumerable<MarketData>>(response);
            return data;
        }
    }
}
