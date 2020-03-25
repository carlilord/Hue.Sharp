using System;
using System.Drawing;

namespace Hue.Sharp.Data
{
    public sealed class LightParameters : BaseLightState
    {
        /// <summary>
        /// transitiontime
        /// in centiseconds
        /// </summary>
        public int? TransitionTime { get; set; }

        public LightParameters()
        {
        }

        public void SetColor(Color color)
        {
            var brightness = color.GetBrightness();
            var hue = color.GetHue();
            var saturation = color.GetSaturation();

            Brightness = (int)ConvertRange(brightness, 0.0f, 1.0f, 0.0f, 254.0f);
            Hue = (int)ConvertRange(hue, 0.0f, 360.0f, 0.0f, 65535.0f);
            Saturation = (int)ConvertRange(saturation, 0.0f, 1.0f, 0.0f, 254.0f);
        }

        public void SetColorTemperature(int temperature)
        {
            // Normalize value
            temperature = Math.Max(154, temperature);
            temperature = Math.Min(500, temperature);

            ColorTemperature = temperature;
        }

        public void SetAlert(AlertState alertState)
        {
            Alert = alertState;
        }

        public void SetTransitionTime(int milliSeconds)
        {
            TransitionTime = milliSeconds * 10;
        }

        private float ConvertRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax)
        {
            var oldRange = oldMax - oldMin;
            float newValue;
            if (oldRange == 0)
            {
                newValue = newMin;
            }
            else
            {
                var newRange = newMax - newMin;
                newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
            }

            return newValue;
        }
    }
}
