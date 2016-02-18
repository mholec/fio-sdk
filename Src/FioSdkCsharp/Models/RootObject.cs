using Newtonsoft.Json;

namespace FioSdkCsharp.Models
{
    public class RootObject
    {
        [JsonProperty(PropertyName = "accountStatement")]
        public AccountStatement AccountStatement { get; set; }
    }
}