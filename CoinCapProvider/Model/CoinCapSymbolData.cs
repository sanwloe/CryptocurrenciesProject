using Newtonsoft.Json;
using System.ComponentModel;

namespace CoinCapProvider.Model
{
    public class CoinCapSymbolData
    {
        [JsonProperty("id")]
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public decimal Supply { get; set; }
        [JsonProperty("maxSupply")]
        [DefaultValue(0)]
        public decimal? MaxSupply { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        [JsonProperty("priceUsd")]
        public decimal Price { get; set; }
        [JsonProperty("changePercent24hr")]
        public decimal PriceChangePercent { get; set; }
    }
}
