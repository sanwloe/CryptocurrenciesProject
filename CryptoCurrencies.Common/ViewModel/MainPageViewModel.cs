using CryptoCurrencies.Common.Model;
using ProvidersFactory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Common.ViewModel
{
    public class MainPageViewModel : ViewModelBaseT<MainPageModel>
    {
        private RestClientFactory _factory;
        public MainPageViewModel(RestClientFactory restClientFactory)
        {
            _factory = restClientFactory;
        }
        protected override async Task ViewLoadedAsync()
        {
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            var client = _factory.GetRestClient(DataModels.Enums.ExchangeType.BinanceFutures);
            var data = await client.GetSymbols();
            if (data.IsSuccess) 
            {
                Model.Symbols = new ObservableCollection<DataModels.Models.SymbolData>(data.Result);
            }
        }
    }
}
