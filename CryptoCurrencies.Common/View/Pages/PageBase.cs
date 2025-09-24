using CryptoCurrencies.Common.Services;
using CryptoCurrencies.Common.ViewModel;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCurrencies.Common.View.Pages
{
    public class PageBase : Page
    {
        public static readonly DependencyProperty DXTabOwnerProperty = DependencyProperty.Register("DXTabOwner", typeof(DXTabControl), typeof(PageBase), new PropertyMetadata(null));
        public DXTabControl DXTabOwner { get => (DXTabControl)GetValue(DXTabOwnerProperty); set => SetValue(DXTabOwnerProperty, value); }

        private BaseViewModel ViewModel { get => (BaseViewModel)DataContext; }
        public PageBase()
        {
            
        }
    }
}
