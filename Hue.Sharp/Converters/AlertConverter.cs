using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hue.Sharp.Data;

namespace Hue.Sharp.Converters
{
    public class AlertConverter : JsonConverter<AlertState>
    {
        public AlertConverter()
        {
        }

        public override AlertState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.GetString())
            {
                case Const.Once:
                    return AlertState.Once;
                case Const.Repeating:
                    return AlertState.Repeating;
                default:
                    return AlertState.None;
            }
        }

        public override void Write(Utf8JsonWriter writer, AlertState value, JsonSerializerOptions options)
        {
            var toWrite = value == AlertState.Repeating ? Const.Repeating : Const.Once;
            writer.WriteStringValue(toWrite);
        }
    }
}
