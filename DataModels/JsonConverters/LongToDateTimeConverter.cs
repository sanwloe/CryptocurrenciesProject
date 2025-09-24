using Newtonsoft.Json;

namespace DataModels.Converters
{
    public class LongToDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return default;

            long unixMilliseconds = Convert.ToInt64(reader.Value);
            return DateTimeOffset.FromUnixTimeMilliseconds(unixMilliseconds).UtcDateTime;
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            long unixMilliseconds = new DateTimeOffset(value).ToUnixTimeMilliseconds();
            writer.WriteValue(unixMilliseconds);
        }
    }
}
