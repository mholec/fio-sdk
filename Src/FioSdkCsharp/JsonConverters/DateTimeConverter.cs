using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FioSdkCsharp.JsonConverters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            DateTime dt = DateTime.ParseExact(str, "yyyy-MM-ddzzz", new CultureInfo("cs-CZ"));

            return dt;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}