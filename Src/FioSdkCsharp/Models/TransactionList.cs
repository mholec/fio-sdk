using System.Collections.Generic;
using Newtonsoft.Json;

namespace FioSdkCsharp.Models
{
    public class TransactionList
    {
        [JsonProperty(PropertyName = "transaction")]
        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return Transactions == null ? "---" : Transactions.Count + " transactions";
        }
    }
}