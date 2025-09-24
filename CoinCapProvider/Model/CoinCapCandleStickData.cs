using DataModels.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapProvider.Model
{
    public class CoinCapCandleStickData
    {
        [JsonProperty("High")]
        public decimal HighPrice { get; set; }
        [JsonProperty("Low")]
        public decimal LowPrice { get; set; }
        [JsonProperty("Open")]
        public decimal OpenPrice { get; set; }
        [JsonProperty("Close")]
        public decimal ClosePrice { get; set; }
        [JsonConverter(typeof(LongToDateTimeConverter))]
        [JsonProperty("Time")]
        public DateTime OpenTime { get; set; }
    }
}
