using CryptoCurrencies.Common.Model;
using DataModels.Enums;
using DataModels.Models;
using Newtonsoft.Json;
using ProviderAbstract.Classes;
using ProviderAbstract.Helpers;
using ProviderAbstract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCapProvider
{
    public class CoinMarketCapRestClient : IBaseRestClient
    {
        private HttpClient _httpClient;
        #region endpoints
        private const string BaseUrl = "https://pro-api.coinmarketcap.com/";
        private const string TopSymbolsEndPoint = "v1/cryptocurrency/trending/latest";
        #endregion
        public CoinMarketCapRestClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "be25d815-f94f-45cc-807e-18b176e6f569");
            _httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }
        public async Task<RequestResult<IEnumerable<SymbolData>>> GetSymbols()
        {
            var response = await _httpClient.GetAsync(TopSymbolsEndPoint);
            var result = await RequestHelper.GetResultFromResponse<IEnumerable<SymbolData>>(response);
            return result;
        }
        public Task<RequestResult<IEnumerable<MarketData>>> GetMarketsBySymbol(string symbol)
        {
            throw new NotImplementedException();
        }
        public Task<RequestResult<IEnumerable<CandleStickData>>> GetCandleStickChartData(string symbol, TimeInterval interval, DateTime? start, DateTime? end)
        {
            throw new NotImplementedException();
        }
    }
}
