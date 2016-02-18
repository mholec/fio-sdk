using System;
using System.Net;
using System.Text;
using FioSdkCsharp.Models;
using Newtonsoft.Json;

namespace FioSdkCsharp
{
    public class ApiExplorer
    {
        private readonly string _authToken;

        public ApiExplorer(string authToken)
        {
            _authToken = authToken;
        }

        /// <summary>
        /// Returns deserialized list of transactions wrapped in AccountStatement
        /// </summary>
        public AccountStatement Account(TransactionFilter filter)
        {
            string url = string.Format(FioUrl.Transactions, _authToken, filter.DateFrom, filter.DateTo, Format.Json.ToString().ToLowerInvariant());

            try
            {
                string data = DownloadData(url);
                return JsonConvert.DeserializeObject<RootObject>(data).AccountStatement;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Data can not be provided", e);
            }
        }

        /// <summary>
        /// Returns data in original form from FIO API
        /// </summary>
        public string Account(TransactionFilter filter, Format format)
        {
            string url = string.Format(FioUrl.Transactions, _authToken, filter.DateFrom, filter.DateTo, format.ToString().ToLowerInvariant());

            try
            {
                return DownloadData(url);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Data can not be provided", e);
            }
        }

        /// <summary>
        /// Downloads data as string from FIO API 
        /// </summary>
        private string DownloadData(string url)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("user-agent", "FioSdkCsharp");
                webClient.Encoding = Encoding.UTF8;

                return webClient.DownloadString(url);
            }
        }
    }
}
