using CryptoCurrencies.Common.Utils;
using DataModels.Models;
using System.Collections.ObjectModel;

namespace CryptoCurrencies.Common.Model
{
    public class DashboardTabModel : DataModelBase
    {
        public DashboardTabModel()
        {
            Symbols = new SortCollection<SymbolData>([]);
        }
        public SortCollection<SymbolData> Symbols { get => GetValue<SortCollection<SymbolData>>(); set => SetValue(value); } 
        public string TextFilter { get => GetValue<string>(); set => SetValue(value); }
    }
}
