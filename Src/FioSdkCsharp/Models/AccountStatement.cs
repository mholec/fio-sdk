using Newtonsoft.Json;

namespace FioSdkCsharp.Models
{
    public class AccountStatement
    {
        [JsonProperty(PropertyName = "info")]
        public Info Info { get; set; }

        [JsonProperty(PropertyName = "transactionList")]
        public TransactionList TransactionList { get; set; }
    }
}