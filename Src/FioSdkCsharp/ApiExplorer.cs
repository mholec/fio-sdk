using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FioSdkCsharp.JsonConverters;
using FioSdkCsharp.Models;

namespace FioSdkCsharp
{
    public class ApiExplorer
    {
        private readonly string authToken;
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public ApiExplorer(string authToken, HttpClient httpClient = null)
        {
            this.authToken = authToken;
            
            this.jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true,
            };
            this.jsonSerializerOptions.Converters.Add(new DateTimeConverter());

            this.httpClient = httpClient ?? new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("SrcLibrary", "nuget.org/fiosdk");
        }

        /// <summary>
        /// Returns transactions in selected period
        /// </summary>
        public async Task<AccountStatement> PeriodsAsync(TransactionFilter filter, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Periods, authToken, filter.DateFrom, filter.DateTo, Format.Json.AsString());

            try
            {
                Stream data = await GetAsync(url, ctx);
                RootObject result = await JsonSerializer.DeserializeAsync<RootObject>(data, jsonSerializerOptions, ctx).ConfigureAwait(false);
                data.Dispose();
                
                return result.AccountStatement;
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

        /// <summary>
        /// Returns new transactions from last call
        /// </summary>
        public async Task<AccountStatement> LastAsync(CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Last, authToken, Format.Json.AsString());

            try
            {
                Stream data = await GetAsync(url, ctx);
                RootObject result = await JsonSerializer.DeserializeAsync<RootObject>(data, jsonSerializerOptions, ctx).ConfigureAwait(false);
                data.Dispose();
                
                return result.AccountStatement;
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

        /// <summary>
        /// Returns transactions in selected period in requested format
        /// </summary>
        public async Task<string> PeriodsAsync(TransactionFilter filter, Format format, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Periods, authToken, filter.DateFrom, filter.DateTo, format.AsString());

            try
            {
                return await GetStringAsync(url, ctx).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

        /// <summary>
        /// Returns new transactions from last call in requested format
        /// </summary>
        public async Task<string> LastAsync(Format format, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Last, authToken, format.ToString().ToLowerInvariant());

            try
            {
                return await GetStringAsync(url, ctx).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

        /// <summary>
        /// Changes last check date (suitable for Last() method)
        /// </summary>
        public async Task SetLastDownloadDate(DateTime date, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.SetLast, authToken, date.ToString(Constants.DateFormat));

            try
            {
                await GetAsync(url, ctx).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception("Last download date has not been changed", e);
            }
        }

        /// <summary>
        /// Changes last check date (suitable for Last() method)
        /// </summary>
        public async Task SetLastDownloadDateAsync(DateTime date, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.SetLast, authToken, date.ToString(Constants.DateFormat));

            try
            {
                await GetAsync(url, ctx).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception("Last download date has not been changed", e);
            }
        }

        private async Task<Stream> GetAsync(string url, CancellationToken ctx)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url, ctx);
            return await response.Content.ReadAsStreamAsync();
        }
        
        private async Task<string> GetStringAsync(string url, CancellationToken ctx)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url, ctx);
            return await response.Content.ReadAsStringAsync();
        }
    }
}