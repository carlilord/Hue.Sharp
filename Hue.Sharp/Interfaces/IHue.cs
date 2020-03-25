using System;
using System.Threading.Tasks;
using Hue.Sharp.Data;

namespace Hue.Sharp
{
    public interface IHue
    {
        public Task<Response> GetInfoOfAllLightsAsync();
        public void ChangeUser(string newUser);
    }
}
