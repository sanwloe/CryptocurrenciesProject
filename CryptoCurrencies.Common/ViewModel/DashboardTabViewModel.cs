using CommunityToolkit.Mvvm.Input;
using CryptoCurrencies.Common.Model;
using CryptoCurrencies.Common.View.Content;
using ProvidersFactory;

namespace CryptoCurrencies.Common.ViewModel
{
    public class DashboardTabViewModel : ViewModelBaseT<DashboardTabModel>
    {
        private readonly ProviderFactory _factory = null!;
        public DashboardTabViewModel()
        {
            
        }
        protected internal override void Initialize()
        {
            base.Initialize();
            Model.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Model.TextFilter))
            {
                ApplyFilter();
            }
        }
        public DashboardTabViewModel(ProviderFactory restClientFactory)
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
            var client = _factory.GetProvider(DataModels.Enums.ExchangeType.BinanceFutures);
            var data = await client.GetSymbolsAsync();
            if (data.IsSuccess) 
            {
                Model.Symbols = new(data.Result.OrderBy(x => x.Symbol).ToList());
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
            this.TabNavigationService.ShowTab(newTab, $"Details - {data.Symbol}");
        }
        private void ApplyFilter()
        {
            if(string.IsNullOrEmpty(Model.TextFilter))
            {
                Model.Symbols.Refresh();
            }
            else
            {
                Model.Symbols.Sort((data) =>
                {
                    return data.Symbol.Contains(Model.TextFilter,StringComparison.InvariantCultureIgnoreCase) 
                    || data.Symbol.Contains(Model.TextFilter,StringComparison.InvariantCultureIgnoreCase);
                });         
            }
        }
    }
}
