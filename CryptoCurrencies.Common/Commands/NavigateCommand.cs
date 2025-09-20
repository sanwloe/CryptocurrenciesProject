using CryptoCurrencies.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Common.Commands
{
    public class NavigateCommand
    {
        private object _model;
        public NavigateCommand(object model)
        {
            _model = model;
        }
        public object GetData()
        {
            return _model;
        }
    }
}
