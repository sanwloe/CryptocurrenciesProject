using CryptoCurrencies.Common.Extensions.XAML;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProvidersFactory;

namespace CryptocurrenciesProject
{
    public class Program
    {
        public static IHost AppHost { get; private set; } = null!;
        [STAThread]
        public static void Main(string[] args) 
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices(services => 
            {
                services.AddSingleton<App>();
                services.AddSingleton<RestClientFactory>();
            });
            var host = AppHost = hostBuilder.Build();
            var app = AppHost.Services.GetService<App>();
            DISource.ServiceProvider = host.Services;
            app!.Run();
        }
    }
}
