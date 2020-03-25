namespace Hue.Sharp.Data
{
    public interface IMessageHandler
    {
        public Response GetParsedResponse(string json);
        public string GetSerializedParameters(LightParameters parameters);
    }
}
