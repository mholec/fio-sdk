using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class AccountStatement
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("transactionList")]
        public TransactionList TransactionList { get; set; }
    }
}