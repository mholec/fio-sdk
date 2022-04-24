using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FioSdkCsharp.JsonConverters;
using FioSdkCsharp.Models;

namespace FioSdkCsharp
{
    public class FioClient : IFioClient
    {
        private readonly FioClientConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public FioClient(HttpClient httpClient, FioClientConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            _jsonSerializerOptions.Converters.Add(new FioDateTimeConverter());
        }

        /// <summary>
        /// Creates statically new instance of FioClient
        /// </summary>
        public static IFioClient Create(HttpClient httpClient, FioClientConfiguration configuration)
        {
            return new FioClient(httpClient, configuration);
        }

        /// <summary>
        /// Returns transactions in selected period
        /// </summary>
        public async Task<AccountStatement> PeriodsAsync(TransactionFilter filter, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Periods, _configuration.AuthToken, filter.DateFrom, filter.DateTo, Format.Json.AsString());

            RootObject result;

            await using (var data = await GetAsync(url, ctx))
            {
                result = await JsonSerializer.DeserializeAsync<RootObject>(data, _jsonSerializerOptions, ctx).ConfigureAwait(false);
                await data.DisposeAsync();
            }

            return result!.AccountStatement;
        }

        /// <summary>
        /// Returns new transactions from last call
        /// </summary>
        public async Task<AccountStatement> LastAsync(CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Last, _configuration.AuthToken, Format.Json.AsString());

            RootObject result;

            await using (var data = await GetAsync(url, ctx))
            {
                result = await JsonSerializer.DeserializeAsync<RootObject>(data, _jsonSerializerOptions, ctx).ConfigureAwait(false);
                await data.DisposeAsync();
            }

            return result!.AccountStatement;
        }

        /// <summary>
        /// Returns transactions in selected period in requested format
        /// </summary>
        public async Task<string> PeriodsAsync(TransactionFilter filter, Format format, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Periods, _configuration.AuthToken, filter.DateFrom, filter.DateTo, format.AsString());
            return await GetStringAsync(url, ctx).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns new transactions from last call in requested format
        /// </summary>
        public async Task<string> LastAsync(Format format, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.Last, _configuration.AuthToken, format.ToString().ToLowerInvariant());
            return await GetStringAsync(url, ctx).ConfigureAwait(false);
        }

        /// <summary>
        /// Changes last check date (suitable for Last() method)
        /// </summary>
        public async Task SetLastDownloadDateAsync(DateTime date, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.SetLastDate, _configuration.AuthToken, date.ToString(Constants.DateFormat));
            await GetAsync(url, ctx).ConfigureAwait(false);
        }

        /// <summary>
        /// Changes last check date (suitable for Last() method)
        /// </summary>
        public async Task SetLastDownloadIdAsync(long id, CancellationToken ctx = new CancellationToken())
        {
            string url = string.Format(FioUrl.SetLastId, _configuration.AuthToken, id);
            await GetAsync(url, ctx).ConfigureAwait(false);
        }

        private async Task<Stream> GetAsync(string url, CancellationToken ctx)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url, ctx);
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                throw new FioClientException("API Rate Limit", null, ExceptionReason.RateLimit);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new FioClientException("Validation Failed", null, ExceptionReason.BadRequest);
            }

            if (response.StatusCode == HttpStatusCode.RequestEntityTooLarge)
            {
                throw new FioClientException("Validation Failed", null, ExceptionReason.TooManyItems);
            }

            try
            {
                return await response.Content.ReadAsStreamAsync();
            }
            catch (Exception e)
            {
                throw new FioClientException("Data can not be provided!", e);
            }
        }
        
        private async Task<string> GetStringAsync(string url, CancellationToken ctx)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url, ctx);
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                throw new FioClientException("API Rate Limit", null, ExceptionReason.RateLimit);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new FioClientException("Validation Failed", null, ExceptionReason.BadRequest);
            }

            try
            {
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw new FioClientException("Data can not be provided!", e);
            }
        }
    }
}