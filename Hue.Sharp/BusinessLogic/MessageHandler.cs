using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Hue.Sharp.Converters;
using Hue.Sharp.Data;

namespace Hue.Sharp.BusinessLogic
{
    public class MessageHandler : IMessageHandler
    {
        private JsonSerializerOptions options;
        public MessageHandler()
        {
            options = new JsonSerializerOptions() { IgnoreNullValues = true };
            options.Converters.Add(new AlertConverter());
        }

        public Response GetParsedResponse(string json)
        {
            using var document = JsonDocument.Parse(json);
            var response = new Response();
            if (document.RootElement.ValueKind == JsonValueKind.Array)
            {
                var names = document.RootElement
                    .EnumerateArray()
                    .SelectMany(o => o.EnumerateObject())
                    .Select(p => p.Name);

                var firstPropName = names.FirstOrDefault();
                
                if (firstPropName == Const.Error)
                {
                    response = JsonSerializer.Deserialize<Response[]>(json).FirstOrDefault();
                    response.IsSuccessful = false;
                    return response;
                }

                if (firstPropName == Const.Success)
                {
                    response.IsSuccessful = true;
                    return response;
                }

                return response;
            }

            response.Lights = new List<Light>();
            var ids = document.RootElement
                    .EnumerateObject()
                    .Select(p => p.Name);

            // Multiple Lights
            if (int.TryParse(ids.FirstOrDefault(), out int res))
            {
                var dict = JsonSerializer.Deserialize<Dictionary<string, Light>>(json, options);
                response.Lights = dict.Select(kv =>
                {
                    var light = kv.Value;
                    light.Id = int.Parse(kv.Key);
                    return light;
                }).ToList();
            }
            // Single Light
            else
            {
                response.Lights.Add(JsonSerializer.Deserialize<Light>(json, options));
            }
            
            response.IsSuccessful = true;
            return response;
        }

        public string GetSerializedParameters(LightParameters parameters)
        {
            return JsonSerializer.Serialize(parameters, options);
        }
    }
}
