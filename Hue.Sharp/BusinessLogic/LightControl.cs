using System;
using System.Drawing;
using System.Threading.Tasks;
using Hue.Sharp.Data;
using Hue.Sharp.Interfaces;

namespace Hue.Sharp
{
    public class LightControl : ILightContol
    {
        private readonly IMessageBroker messageBroker;

        public int Id { get; set; }
        public string Name { get; set; }

        public LightControl(IMessageBroker messageBroker, int id, string name)
        {
            this.messageBroker = messageBroker;
            Id = id;
            Name = name;
        }

        public Task<Response> ChangeParametersAsync(LightParameters parameters)
        {
            return messageBroker.ChangeLightParametersAsync(Id, parameters);
        }

        public Task<Response> GetInfoAsync()
        {
            return messageBroker.GetInfoOfLightAsync(Id);
        }

        public Task<Response> SetColor(Color color)
        {
            var parameters = new LightParameters();
            parameters.SetColor(color);
            return ChangeParametersAsync(parameters);
        }

        public Task<Response> TurnOffAsync()
        {
            return ChangeParametersAsync(new LightParameters { On = false });
        }

        public Task<Response> TurnOnAsync()
        {
            return ChangeParametersAsync(new LightParameters { On = true });
        }
    }
}
