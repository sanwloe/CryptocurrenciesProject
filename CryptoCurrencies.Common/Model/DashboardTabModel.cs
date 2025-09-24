using DataModels.Models;
using System.Collections.ObjectModel;

namespace CryptoCurrencies.Common.Model
{
    public class DashboardTabModel : DataModelBase
    {
        public DashboardTabModel()
        {
            Symbols = [];
        }
        public ObservableCollection<SymbolData> Symbols { get => GetValue<ObservableCollection<SymbolData>>(); set => SetValue(value); } 
    }
}
