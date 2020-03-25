using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hue.Sharp.Data;
using Hue.Sharp.Interfaces;

namespace Hue.Sharp.BusinessLogic
{
    public class MessageBroker : IMessageBroker
    {
        private HttpClient httpClient;
        private string user;
        private readonly string ipAddress;
        private readonly IMessageHandler messageHandler;

        public MessageBroker(string ipAddress, string user, IMessageHandler messageHandler)
        {
            httpClient = new HttpClient();
            this.user = user;
            this.ipAddress = ipAddress;
            this.messageHandler = messageHandler;
        }

        public async Task<Response> ChangeLightParametersAsync(int id, LightParameters parameters)
        {
            var url = string.Format(Const.AdaptLight, ipAddress, user, id);
            var json = messageHandler.GetSerializedParameters(parameters);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PutAsync(url, content);

            return messageHandler.GetParsedResponse(await result.Content.ReadAsStringAsync());
        }

        public void ChangeUser(string newUser)
        {
            user = newUser;
        }

        public async Task<Response> GetInfoOfAllLightsAsync()
        {
            var url = string.Format(Const.LightsInfo, ipAddress, user);
            var result = await httpClient.GetAsync(url);

            return messageHandler.GetParsedResponse(await result.Content.ReadAsStringAsync());
        }

        public async Task<Response> GetInfoOfLightAsync(int id)
        {
            var url = string.Format(Const.LightInfo, ipAddress, user, id);
            var result = await httpClient.GetAsync(url);

            return messageHandler.GetParsedResponse(await result.Content.ReadAsStringAsync());
        }
    }
}
