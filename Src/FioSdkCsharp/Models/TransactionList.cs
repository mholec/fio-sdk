using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class TransactionList
    {
        [JsonPropertyName( "transaction")]
        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return Transactions == null ? "---" : Transactions.Count + " transactions";
        }
    }
}