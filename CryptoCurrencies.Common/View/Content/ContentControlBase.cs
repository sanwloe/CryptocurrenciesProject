using CryptoCurrencies.Common.ViewModel;
using DevExpress.Xpf.Core;
using System.ComponentModel;
using System.Windows;

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
        public ContentControlBase()
        {
            Loaded += Control_Loaded;
        }
        private async void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if(!DesignerProperties.GetIsInDesignMode(this))
            {
                await ViewModel.ViewLoadedAsync();
            }
            Loaded -= Control_Loaded;
        }
    }
}
