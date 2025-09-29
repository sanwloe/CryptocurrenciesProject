using CryptoCurrencies.Common.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace CryptoCurrencies.Common.View.Windows
{
    public class WindowBase<TDataModel> : Window where TDataModel : new()
    {
        public static readonly DependencyProperty ResultProperty = 
            DependencyProperty.Register("Result",typeof(object),typeof(WindowBase<TDataModel>),new PropertyMetadata(null,new (ResultPropertyChanged)));
        private static void ResultPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is WindowBase<TDataModel> window)
            {
                window.DialogResult = true;
            }
        }
        public ViewModelBaseT<TDataModel> ViewModel { get => (ViewModelBaseT<TDataModel>)DataContext; }
        public object? Result { get => GetValue(ResultProperty);  set => SetValue(ResultProperty, value); }
        public WindowBase()
        {
            Loaded += WindowBase_Loaded;
        }
        private async void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                await ViewModel.ViewLoadedAsync();
            }
            Loaded -= WindowBase_Loaded;
        }
    }
}
