using CoinCapProvider.RestApi;
using CommunityToolkit.Mvvm.Input;
using CryptoCurrencies.Common.Model;
using DataModels.Models;
using ProviderAbstract.Classes;
using ProviderAbstract.Interface;
using ProvidersFactory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Common.ViewModel
{
    public class SymbolDetailsViewModel : ViewModelBaseT<SymbolDetailsModel>
    {
        private RestClientFactory _restClientFactory;
        private IBaseRestClient _coinCapRestClient;


        public RelayCommand<MarketData> OpenExchangeCommand { get; set; }
        public SymbolDetailsViewModel(RestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory;
            _coinCapRestClient = restClientFactory.GetRestClient(DataModels.Enums.ExchangeType.CoinCap);

            OpenExchangeCommand = new RelayCommand<MarketData>(TryOpenExchange!);
        }
        internal protected override async Task ViewLoadedAsync()
        {
            var markets = await LoadMarketsAsync();
            Model.Markets = new ObservableCollection<MarketData>(markets);
        }
        private async Task<IEnumerable<MarketData>> LoadMarketsAsync()
        {
            var result = await _coinCapRestClient.GetMarketsBySymbol(Model.SymbolData.Name);
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
                MessageBox.Show($"Не вдалось відкрити сайт для {marketData.MarketName}");
            }
        }
    }
}
