using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Hue.Sharp.BusinessLogic;
using Hue.Sharp.Data;
using Hue.Sharp.Interfaces;

namespace Hue.Sharp
{
    public class Hue : IHue
    {
        private IMessageBroker messageBroker;
        public ImmutableList<ILightContol> Lights { get; private set; }

        public Hue(string ipAddress, string user)
        {
            messageBroker = new MessageBroker(ipAddress, user, new MessageHandler());
        }

        public async Task<Response> GetInfoOfAllLightsAsync()
        {
            var result = await messageBroker.GetInfoOfAllLightsAsync();
            var lightList = new List<LightControl>();
            foreach (var light in result.Lights)
            {
                lightList.Add(new LightControl(messageBroker, light.Id, light.Name));
            }

            Lights = lightList.ToImmutableList<ILightContol>();
            return result;
        }

        public void ChangeUser(string newUser)
        {
            messageBroker.ChangeUser(newUser);
        }
    }
}
