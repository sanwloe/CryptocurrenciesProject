using DataModels.Enums;

namespace DataModels.Models
{
    public class SymbolData
    {
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Supply { get; set; }
        public decimal MaxSupply { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal PriceChangePercent { get; set; }
        public ExchangeType ExchangeType { get; set; }
    }
}
