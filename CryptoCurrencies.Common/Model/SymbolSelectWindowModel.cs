using CryptoCurrencies.Common.Utils;
using DataModels.Enums;
using DataModels.Models;

namespace CryptoCurrencies.Common.Model
{
    public class SymbolSelectWindowModel : DataModelBase
    {
        public SymbolSelectWindowModel()
        {
            ExchangeSymbols = [];
            BinanceFutureSymbols = new SortCollection<SymbolData>([]);
            CoinCapSymbols = new SortCollection<SymbolData>([]);
        }
        public string TextFilter { get => GetValue<string>(); set => SetValue(value); }
        public SortCollection<SymbolData> BinanceFutureSymbols { get=> GetValue<SortCollection<SymbolData>>(); set => SetValue(value); }
        public SortCollection<SymbolData> CoinCapSymbols {  get=> GetValue<SortCollection<SymbolData>>(); set => SetValue(value); }
        public Dictionary<ExchangeType,SortCollection<SymbolData>> ExchangeSymbols { get => GetValue<Dictionary<ExchangeType, SortCollection<SymbolData>>>(); set => SetValue(value); }
    }
}
