using DataModels.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Common.Model
{
    public class SymbolDetailsModel : DataModelBase
    {
        public SymbolData SymbolData { get => GetValue<SymbolData>(); set => SetValue(value); }
        public ObservableCollection<MarketData> Markets { get => GetValue<ObservableCollection<MarketData>>(); set => SetValue(value); }
        






    }
}
