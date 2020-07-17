using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dictionary.WebUi.Misc
{
    public class StandardResult<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}