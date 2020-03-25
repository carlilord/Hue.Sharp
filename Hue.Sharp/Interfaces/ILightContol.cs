using System.Drawing;
using System.Threading.Tasks;
using Hue.Sharp.Data;

namespace Hue.Sharp
{
    public interface ILightContol
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Task<Response> TurnOnAsync();
        public Task<Response> TurnOffAsync();
        public Task<Response> SetColor(Color color);
        public Task<Response> GetInfoAsync();
        public Task<Response> ChangeParametersAsync(LightParameters parameters);
    }
}