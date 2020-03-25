using System;
using System.Text.Json.Serialization;
using Hue.Sharp.Enums;

namespace Hue.Sharp.Data
{
    public class ErrorDetails
    {
        private ErrorType errorType;

        [JsonPropertyName("type")]
        public ErrorType Type
        {
            get
            {
                return errorType;
            }
            set
            {
                errorType = Enum.IsDefined(typeof(ErrorType), value) ? value: ErrorType.Unknown;
            }
        }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public ErrorDetails()
        {
            Type = ErrorType.Unknown;
        }
    }
}
