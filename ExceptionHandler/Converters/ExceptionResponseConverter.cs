using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExceptionHandler.Converters
{
    public class ExceptionResponseConverter : JsonConverter<ExceptionResponse>
    {
        public override ExceptionResponse Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions options)
        {
            var resultString = reader.GetString();

            if (resultString is null)
            {
                throw new JsonException("Cannot convert null value to ExceptionResponse.");
            }

            var parts = resultString?.Split(':');

            if (parts.Length != 3)
            {
                throw new JsonException("Invalid format for ExceptionResponse.");
            }

            var statusCode = parts[2].Trim().Split(';')[0];

            var responseMessage = parts[3].Trim().Split(';')[0];

            return new ExceptionResponse()
            {
                StatusCode = int.Parse(statusCode),
                Message = responseMessage
            };
        }

        public override void Write(Utf8JsonWriter writer, ExceptionResponse response, JsonSerializerOptions options)
        {
            string result = $"Response status code: {response.StatusCode};\n" +
                $"Response message: {response.Message};\n";

            writer.WriteStringValue(result);
        }
    }
}
