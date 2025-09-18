using CryptoCurrencies.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoCurrencies.Common.View.Pages
{
    public abstract class PageBase : Page
    {
        private BaseViewModel ViewModel { get => (BaseViewModel)DataContext; }
        public PageBase()
        {
            Loaded += PageBase_Loaded;
        }
        private async void PageBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await ViewModel.LoadedCommand.ExecuteAsync(null);
        }
    }
}
