using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;

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
