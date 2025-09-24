using BinanceProvider.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BinanceProvider.Converters
{
    internal class BinanceFutureCandleStickDataConverter : JsonConverter<BinanceFuturesCandleStickData>
    {
        public override BinanceFuturesCandleStickData? ReadJson(JsonReader reader, Type objectType, BinanceFuturesCandleStickData? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);

            return new BinanceFuturesCandleStickData()
            {
                OpenTime = DateTimeOffset.FromUnixTimeMilliseconds((long)array[0]).LocalDateTime,
                OpenPrice = (decimal)array[1],
                HighPrice = (decimal)array[2],
                LowPrice = (decimal)array[3],
                ClosePrice = (decimal)array[4],
            };
        }

        public override void WriteJson(JsonWriter writer, BinanceFuturesCandleStickData? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
