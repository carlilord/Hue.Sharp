using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hue.Sharp.Data
{
    public class Response
    {
        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        [JsonPropertyName("error")]
        public ErrorDetails ErrorDetails { get; set; }

        public IList<Light> Lights { get; set; }
    }
}
