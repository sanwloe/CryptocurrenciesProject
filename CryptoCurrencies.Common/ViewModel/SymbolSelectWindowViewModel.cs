using CryptoCurrencies.Common.Model;
using CryptoCurrencies.Common.Utils;
using DataModels.Enums;
using DataModels.Models;
using ProvidersFactory;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace CryptoCurrencies.Common.ViewModel
{
    internal class SymbolSelectWindowViewModel : ViewModelBaseT<SymbolSelectWindowModel>
    {
        private readonly ProviderFactory _restClientFactory = null!;
        public SymbolSelectWindowViewModel()
        {
            
        }

        private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Model.TextFilter)) 
            {
                ApplyFilter();
            }
        }
        public SymbolSelectWindowViewModel(ProviderFactory restClientFactory)
        {
            _restClientFactory = restClientFactory;
        }
        protected internal override void Initialize()
        {
            Model.PropertyChanged += Model_PropertyChanged;
            base.Initialize();
        }
        protected async internal override Task ViewLoadedAsync()
        {
            var result = await LoadSymbolsAsync();
            Model.ExchangeSymbols = result;
        }
        private async Task<Dictionary<ExchangeType,SortCollection<SymbolData>>> LoadSymbolsAsync()
        {
            var data = new ConcurrentDictionary<ExchangeType, SortCollection<SymbolData>>();
            var providers = _restClientFactory.GetAvailableProviders();
            var loadDataTasks = new List<Task>();

            foreach (var provider in providers)
            {
                loadDataTasks.Add(Task.Run(async () =>
                {
                    var result = await provider.Value.GetSymbolsAsync();
                    if (result.IsSuccess) 
                    {
                        data[provider.Key] = new(result.Result.ToList());
                    }
                }));
            }
            await Task.WhenAll(loadDataTasks);

            return data.ToDictionary();
        }
        private void ApplyFilter()
        {
            foreach (var symbols in Model.ExchangeSymbols)
            {
                if (string.IsNullOrEmpty(Model.TextFilter))
                {
                    symbols.Value.Refresh();
                }
                else
                {
                    symbols.Value.Sort((data) =>
                    {
                        return data.Symbol.Contains(Model.TextFilter, StringComparison.InvariantCultureIgnoreCase)
                        || data.Symbol.Contains(Model.TextFilter, StringComparison.InvariantCultureIgnoreCase);
                    });
                }
            }
        }
        public ObservableCollection<SymbolData> GetSymbols(ExchangeType exchangeType)
        {
            if (Model.ExchangeSymbols.ContainsKey(exchangeType))
            {
                return Model.ExchangeSymbols[exchangeType];
            }
            else
            {
                return [];
            }
        }
    }
}
