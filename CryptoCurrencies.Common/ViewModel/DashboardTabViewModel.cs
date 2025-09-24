using CommunityToolkit.Mvvm.Input;
using CryptoCurrencies.Common.Model;
using CryptoCurrencies.Common.View.Content;
using ProvidersFactory;
using System.Collections.ObjectModel;

namespace CryptoCurrencies.Common.ViewModel
{
    public class DashboardTabViewModel : ViewModelBaseT<DashboardTabModel>
    {
        private readonly RestClientFactory _factory = null!;
        public DashboardTabViewModel()
        {
            
        }
        public DashboardTabViewModel(RestClientFactory restClientFactory)
        {
            _factory = restClientFactory;
            ShowTabDetailsCommand = new(ShowTabDetails!);
            //Model.Symbols.Add(new DataModels.Models.SymbolData() { Symbol = "1" });
        }
        public RelayCommand<DataModels.Models.SymbolData> ShowTabDetailsCommand { get; set; } = null!;
        internal protected override async Task ViewLoadedAsync()
        {
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            var client = _factory.GetRestClient(DataModels.Enums.ExchangeType.BinanceFutures);
            var data = await client.GetSymbols();
            if (data.IsSuccess) 
            {
                Model.Symbols = new ObservableCollection<DataModels.Models.SymbolData>(data.Result.OrderBy(x => x.Symbol));
            }
            else
            {
                MessageBox.Show(data.ErrorMessage);
            }
        }
        private void ShowTabDetails(DataModels.Models.SymbolData data)
        {
            var newTab = new SymbolDetailsTab();
            newTab.ViewModel.Model.SymbolData = data;
            this.TabNavigationService.ShowTab(newTab,$"Details - {data.Symbol}");
        }
    }
}
