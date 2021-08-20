using lab_3.Domain;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab_3.Json
{
    public class ShopJsonConverter : JsonConverter<Shop>
    {
        public override Shop Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Shop { Id = reader.GetInt32() };
        }

        public override void Write(Utf8JsonWriter writer, Shop value, JsonSerializerOptions options)
        {
            writer.WriteNumber("ShopId", value.Id);
        }
    }

    public class PriceJsonConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return int.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteString("Price", value.ToString());
        }
    }

    public class MarketLaunchDateJsonConverter : JsonConverter<DateTime>
    {
        public const string DateFormat = "MMM yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), DateFormat, CultureInfo.CreateSpecificCulture("en-EN"));
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteString("MarketLaunchDate", value.ToString(DateFormat));
        }
    }
}
