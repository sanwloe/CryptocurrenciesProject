using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceProvider.Model
{
    public class BinanceFuturesTicker
    {
        public string Symbol { get; set; } = string.Empty;
        public string Name { get => Symbol; }
        public decimal PriceChangePercent { get; set; }
        [JsonProperty("lastPrice")]
        public decimal Price { get; set; }
        public decimal LowPrice { get; set; }
        public decimal HighPrice { get; set; }
    }
}
