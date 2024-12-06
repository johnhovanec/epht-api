using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace epht_api.Converters
{
    public class DecimalZeroAsFloatConverter : JsonConverter<decimal>
    {

        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Simply read and return the decimal value
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            // Write the decimal value as a string with one decimal place
            writer.WriteStringValue(value.ToString("0.0"));
        }

    }
}
