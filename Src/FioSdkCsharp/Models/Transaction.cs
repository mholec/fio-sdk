using System;
using Newtonsoft.Json;

namespace FioSdkCsharp.Models
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "column22")]
        public Column<long> Id { get; set; }

        [JsonProperty(PropertyName = "column0")]
        public Column<DateTime> Date { get; set; }

        [JsonProperty(PropertyName = "column1")]
        public Column<double> Amount { get; set; }

        [JsonProperty(PropertyName = "column14")]
        public Column<string> Currency { get; set; }

        [JsonProperty(PropertyName = "column2")]
        public Column<string> CounterpartAccount { get; set; }

        [JsonProperty(PropertyName = "column10")]
        public Column<string> CounterpartAccountName { get; set; }

        [JsonProperty(PropertyName = "column3")]
        public Column<string> CounterpartBankCode { get; set; }

        [JsonProperty(PropertyName = "column12")]
        public Column<string> CounterpartBankName { get; set; }

        [JsonProperty(PropertyName = "column4")]
        public Column<string> ConstantSymbol { get; set; }

        [JsonProperty(PropertyName = "column5")]
        public Column<string> VariableSymbol { get; set; }

        [JsonProperty(PropertyName = "column6")]
        public Column<string> SpefificSymbol { get; set; }

        [JsonProperty(PropertyName = "column7")]
        public Column<string> Identification { get; set; }

        [JsonProperty(PropertyName = "column16")]
        public Column<string> MessageForReceipient { get; set; }

        [JsonProperty(PropertyName = "column8")]
        public Column<string> Type { get; set; }

        [JsonProperty(PropertyName = "column9")]
        public Column<string> Accountant { get; set; }

        [JsonProperty(PropertyName = "column25")]
        public Column<string> Comment { get; set; }

        [JsonProperty(PropertyName = "column17")]
        public Column<long> InstructionId { get; set; }

        public override string ToString()
        {
            string date = Date != null ? Date.Value.ToString("yyyy-MM-dd") : string.Empty;
            string comment = Comment != null ? Comment.Value : string.Empty;
            string instructionId = InstructionId != null ? InstructionId.Value.ToString() : string.Empty;

            return string.Format("{0} - {1} - {2}", date, instructionId, comment);
        }
    }
}
