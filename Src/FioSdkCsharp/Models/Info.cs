using Newtonsoft.Json;

namespace FioSdkCsharp.Models
{
    public class Info
    {
        [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }

        [JsonProperty(PropertyName = "bankId")]
        public string BankId { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "iban")]
        public string Iban { get; set; }

        [JsonProperty(PropertyName = "bic")]
        public string Bic { get; set; }

        [JsonProperty(PropertyName = "openingBalance")]
        public double OpeningBalance { get; set; }

        [JsonProperty(PropertyName = "closingBalance")]
        public double ClosingBalance { get; set; }

        [JsonProperty(PropertyName = "dateStart")]
        public string DateStart { get; set; }

        [JsonProperty(PropertyName = "dateEnd")]
        public string DateEnd { get; set; }

        [JsonProperty(PropertyName = "yearList")]
        public object YearList { get; set; }

        [JsonProperty(PropertyName = "idList")]
        public object IdList { get; set; }

        [JsonProperty(PropertyName = "idFrom")]
        public long IdFrom { get; set; }

        [JsonProperty(PropertyName = "idTo")]
        public long IdTo { get; set; }

        [JsonProperty(PropertyName = "idLastDownload")]
        public object IdLastDownload { get; set; }

        public override string ToString()
        {
            return AccountId + "/" + BankId + " (" + Currency + ")";
        }
    }
}