using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class Info
    {
        /// <summary>
        /// CZ:
        /// </summary>
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("bankId")]
        public string BankId { get; set; }

        /// <summary>
        /// ISO 4217
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// ISO 13616
        /// </summary>
        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        /// <summary>
        ///  ISO 9362
        /// </summary>
        [JsonPropertyName("bic")]
        public string Bic { get; set; }

        [JsonPropertyName("openingBalance")]
        public double OpeningBalance { get; set; }

        [JsonPropertyName("closingBalance")]
        public double ClosingBalance { get; set; }

        /// <summary>
        /// YYYY-MM-DD+GMT
        /// </summary>
        [JsonPropertyName("dateStart")]
        public string DateStart { get; set; }

        /// <summary>
        /// YYYY-MM-DD+GMT
        /// </summary>
        [JsonPropertyName("dateEnd")]
        public string DateEnd { get; set; }

        /// <summary>
        /// YYYY
        /// </summary>
        [JsonPropertyName("yearList")]
        public object YearList { get; set; }

        [JsonPropertyName("idList")]
        public object IdList { get; set; }

        [JsonPropertyName("idFrom")]
        public long? IdFrom { get; set; }

        [JsonPropertyName("idTo")]
        public long? IdTo { get; set; }

        [JsonPropertyName("idLastDownload")]
        public object IdLastDownload { get; set; }

        public override string ToString()
        {
            return AccountId + "/" + BankId + " (" + Currency + ")";
        }
    }
}