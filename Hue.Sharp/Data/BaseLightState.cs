using System;
using System.Text.Json.Serialization;

namespace Hue.Sharp.Data
{
    public class BaseLightState
    {
        /// <summary>
        /// on
        /// </summary>
        [JsonPropertyName("on")]
        public bool? On { get; set; }

        /// <summary>
        /// bri
        /// 0-254
        /// </summary>
        [JsonPropertyName("bri")]
        public int? Brightness { get; set; }

        /// <summary>
        /// hue
        /// 0-65535
        /// </summary>
        [JsonPropertyName("hue")]
        public int? Hue { get; set; }

        /// <summary>
        /// sat
        /// 0-254
        /// </summary>
        [JsonPropertyName("sat")]
        public int? Saturation { get; set; }

        /// <summary>
        /// xy
        /// </summary>
        [JsonPropertyName("xy")]
        public float[] CIECoordinates { get; set; }

        /// <summary>
        /// ct
        /// 154(cold)-500(warm)
        /// </summary>
        [JsonPropertyName("ct")]
        public int? ColorTemperature { get; set; }

        /// <summary>
        /// alert
        /// </summary>
        [JsonPropertyName("alert")]
        public AlertState? Alert { get; set; }

        public BaseLightState()
        {
        }
    }
}
