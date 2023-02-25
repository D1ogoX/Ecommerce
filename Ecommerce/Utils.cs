using Ecommerce.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ecommerce
{
    public class Utils : IUtils
    {
        public string GetData(string json)
        {
            var o = JsonConvert.DeserializeObject<JObject>(json);
            var h = o.Value<JObject>("Data")
                .Value<JArray>("Houses");

            return h.ToString();
        }
    }
}
