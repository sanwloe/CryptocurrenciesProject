using CommunityToolkit.Mvvm.Input;
using CryptoCurrencies.Common.Services;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CryptoCurrencies.Common.ViewModel
{
    public abstract class ViewModelBaseT<T> : BaseViewModel where T : new()
    {
        protected ViewModelBaseT() : base()
        {
            Model = new T();
        }
        public new T Model { get => GetValue<T>(); set => SetValue(value); }
    }
    public abstract class BaseViewModel : ViewModelBase
    {
        public Dispatcher Dispatcher { get; private set; }
        public TabNavigationService TabNavigationService { get; set; } = null!;
        protected BaseViewModel()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
        }
        public object Model { get => GetValue<object>(); set => SetValue(value); }
        internal protected virtual Task ViewLoadedAsync()
        {
            return Task.CompletedTask;
        }
    }
}
