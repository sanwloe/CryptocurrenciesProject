using DataModels.Enums;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Helpers
{
    public static class DataHelper
    {
        public static void SetExchangeType(IEnumerable<SymbolData> collection, ExchangeType exchangeType)
        {
            foreach (var item in collection) 
            {
                item.ExchangeType = exchangeType;
            }
        }
    }
}
