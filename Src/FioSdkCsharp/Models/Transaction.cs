using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class Transaction
    {
        [JsonPropertyName( "column22")]
        public Column<long> Id { get; set; }

        /// <summary>
        /// YYYY-MM-DD+GMT
        /// </summary>
        [JsonPropertyName( "column0")]
        public Column<DateTime> Date { get; set; }

        [JsonPropertyName( "column1")]
        public Column<decimal> Amount { get; set; }

        /// <summary>
        /// ISO 4217
        /// </summary>
        [JsonPropertyName( "column14")]
        public Column<string> Currency { get; set; }

        [JsonPropertyName( "column2")]
        public Column<string> CounterpartAccount { get; set; }

        [JsonPropertyName( "column10")]
        public Column<string> CounterpartAccountName { get; set; }

        [JsonPropertyName("column3")]
        public Column<string> CounterpartBankCode { get; set; }

        [JsonPropertyName( "column12")]
        public Column<string> CounterpartBankName { get; set; }

        [JsonPropertyName( "column4")]
        public Column<string> ConstantSymbol { get; set; }

        [JsonPropertyName( "column5")]
        public Column<string> VariableSymbol { get; set; }

        [JsonPropertyName( "column6")]
        public Column<string> SpecificSymbol { get; set; }

        [JsonIgnore, EditorBrowsable(EditorBrowsableState.Never)]
        public Column<string> SpefificSymbol { get => SpecificSymbol; set => SpecificSymbol = value; }

        [JsonPropertyName( "column7")]
        public Column<string> Identification { get; set; }

        [JsonPropertyName( "column16")]
        public Column<string> MessageForReceipient { get; set; }

        [JsonPropertyName( "column8")]
        public Column<string> Type { get; set; }

        [JsonPropertyName("column9")]
        public Column<string> Accountant { get; set; }

        [JsonPropertyName("column25")]
        public Column<string> Comment { get; set; }

        [JsonPropertyName( "column17")]
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