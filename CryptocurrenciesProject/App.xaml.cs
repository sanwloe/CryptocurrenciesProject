using System.Configuration;
using System.Data;
using System.Windows;

namespace CryptocurrenciesProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.Resources.MergedDictionaries.Add(
            new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/CryptoCurrencies.Common;component/Themes/DX/Generic.xaml")
            });

            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
