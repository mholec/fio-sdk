using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class Column<T>
    {
        [JsonPropertyName("value")]
        public T Value { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}