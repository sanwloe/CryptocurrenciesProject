namespace CryptoCurrencies.Common.Model
{
    public class CandleStickData
    {
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public DateTime OpenTime { get; set; }
    }
}
