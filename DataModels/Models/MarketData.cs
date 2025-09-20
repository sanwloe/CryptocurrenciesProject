using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class MarketData
    {
        [JsonProperty("exchangeId")]
        public string MarketName { get; set; } = string.Empty;
        [JsonProperty("PriceUsd")]
        public decimal Price { get; set; }
        [JsonProperty("quoteSymbol")]
        public string PriceCurrency { get; set; } = string.Empty;
    }
}
