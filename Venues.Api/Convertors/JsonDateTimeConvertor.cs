using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Venues.Api.Convertors
{
    public class JsonDateTimeConvertor : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = value as DateTime?;
            if (!date.HasValue) throw new InvalidOperationException("JsonDateTimeConvertor not being given a DateTime instance");

            var serializedValue = date.Value.ToString("dd/MM/yyyy");
            writer.WriteValue(serializedValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value as string;
            return ConvertFromString(value);
        }

        public DateTime? ConvertFromString(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;

            if (DateTime.TryParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var demoDate))
                return demoDate;

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}