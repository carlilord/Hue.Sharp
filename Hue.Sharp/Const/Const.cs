using System;
namespace Hue.Sharp
{
    public static class Const
    {
        public const string RegisterApp = "http://{0}/api";

        public const string LightsInfo = "http://{0}/api/{1}/lights";

        public const string LightInfo = "http://{0}/api/{1}/lights/{2}";

        public const string AdaptLight = "http://{0}/api/{1}/lights/{2}/state";

        public const string Success = "success";

        public const string Error = "error";

        public const string Once = "select";

        public const string Repeating = "lselect";
    }
}
