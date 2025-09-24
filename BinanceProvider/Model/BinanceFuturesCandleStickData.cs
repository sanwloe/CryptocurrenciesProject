using BinanceProvider.Converters;
using Newtonsoft.Json;

namespace BinanceProvider.Model
{
    [JsonConverter(typeof(BinanceFutureCandleStickDataConverter))]
    public class BinanceFuturesCandleStickData
    {
        public DateTime OpenTime { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal ClosePrice { get; set; }
    }
}
