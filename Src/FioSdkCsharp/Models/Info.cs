using System.Text.Json.Serialization;

namespace FioSdkCsharp.Models
{
    public class Info
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("bankId")]
        public string BankId { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        [JsonPropertyName("bic")]
        public string Bic { get; set; }

        [JsonPropertyName("openingBalance")]
        public double OpeningBalance { get; set; }

        [JsonPropertyName("closingBalance")]
        public double ClosingBalance { get; set; }

        [JsonPropertyName("dateStart")]
        public string DateStart { get; set; }

        [JsonPropertyName("dateEnd")]
        public string DateEnd { get; set; }

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