using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class RootObject
    {
        [JsonPropertyName("accountStatement")]
        public AccountStatement AccountStatement { get; set; }
    }
}