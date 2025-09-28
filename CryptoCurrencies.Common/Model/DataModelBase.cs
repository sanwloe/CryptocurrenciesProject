using DevExpress.Mvvm;
using System.ComponentModel;

namespace CryptoCurrencies.Common.Model
{
    public class DataModelBase : BindableBase, IDisposable
    {
        public virtual void Dispose()
        {
             
        }
    }
}
