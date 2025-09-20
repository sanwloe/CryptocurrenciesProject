using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CryptoCurrencies.Common.Extensions.XAML
{
    public class DISource : MarkupExtension
    {
        public static IServiceProvider ServiceProvider { get; set; } = null!;
        public Type Type { get; set; } = null!;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ServiceProvider == null) 
            {
                // Design time , інакше можливо контроли не будуть відображатись під час дизайну
                return Activator.CreateInstance(Type) ?? new object();
                throw new NullReferenceException($"{nameof(ServiceProvider)} is null.");
            }
            if (Type == null) 
            {
                throw new NullReferenceException($"{nameof(Type)} is null.");
            }
            return ActivatorUtilities.CreateInstance(ServiceProvider,Type);
        }
    }
}
