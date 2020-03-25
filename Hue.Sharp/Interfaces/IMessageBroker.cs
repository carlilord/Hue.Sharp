using System.Threading.Tasks;
using Hue.Sharp.Data;

namespace Hue.Sharp.Interfaces
{
    public interface IMessageBroker
    {
        public Task<Response> GetInfoOfAllLightsAsync();

        public Task<Response> GetInfoOfLightAsync(int id);

        public Task<Response> ChangeLightParametersAsync(int id, LightParameters parameters);

        public void ChangeUser(string newUser);
    }
}
