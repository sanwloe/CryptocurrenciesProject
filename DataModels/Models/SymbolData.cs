using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class SymbolData
    {
        public string Symbol { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal PriceChangePercent { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public ExchangeType ExchangeType { get; set; }
    }
}
