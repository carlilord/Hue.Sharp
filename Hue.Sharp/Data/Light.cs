using System.Text.Json.Serialization;

namespace Hue.Sharp.Data
{
    public class Light
    {
        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        public Light()
        {
        }
    }
}
