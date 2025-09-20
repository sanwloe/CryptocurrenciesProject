using CryptoCurrencies.Common.Commands;
using CryptoCurrencies.Common.Model;
using CryptoCurrencies.Common.View.Pages;
using CryptoCurrencies.Common.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCurrencies.Common.View.Content
{
    public abstract class ContentControlBase<TDataModel> : System.Windows.Controls.UserControl where TDataModel : new()
    {
        public static readonly DependencyProperty DXTabOwnerProperty = DependencyProperty.Register("DXTabOwner", typeof(DXTabControl), typeof(ContentControlBase<TDataModel>), new PropertyMetadata(new(DXTabOwnerChanged)));
        private static void DXTabOwnerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is ContentControlBase<TDataModel> control && e.NewValue is DXTabControl tabControl)
            {
                control.ViewModel.TabNavigationService = new Services.TabNavigationService(tabControl);
            }
        }
        public DXTabControl DXTabOwner { get => (DXTabControl)GetValue(DXTabOwnerProperty); set => SetValue(DXTabOwnerProperty, value); }
        public ViewModelBaseT<TDataModel> ViewModel { get => (ViewModelBaseT<TDataModel>)DataContext; }
        protected ContentControlBase()
        {
            Loaded += Control_Loaded;
        }

        private async void Control_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.ViewLoadedAsync();
            Loaded -= Control_Loaded;
        }
    }
}
