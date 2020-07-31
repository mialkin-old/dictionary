using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dictionary.WebUi.Misc
{
    public class ResultSerializer : IResultSerializer
    {
        public string Serialize(object result)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            
            return JsonConvert.SerializeObject(result, Formatting.Indented, settings);
        }
    }
}