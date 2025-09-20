using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGeckoProvider.RestApi
{
    public class CoinGeckoRestClient
    {
        private HttpClient _httpClient;
        private const string BaseAdress = "https://api.coingecko.com/api/v3/";
        private const string TickersEndPoint = "https://api.coingecko.com/api/v3/coins/{id}/tickers";
        private const string ApiKey = "";
        public CoinGeckoRestClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseAdress);
        }
        public async Task Check()
        {

        }

    }
}
