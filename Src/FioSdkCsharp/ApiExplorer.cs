using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        /// Returns transactions in selected period
        /// </summary>
        public AccountStatement Periods(TransactionFilter filter)
        {
            string url = string.Format(FioUrl.Periods, _authToken, filter.DateFrom, filter.DateTo, Format.Json.ToString().ToLowerInvariant());

            try
            {
                string data = DownloadData(url);
                return JsonConvert.DeserializeObject<RootObject>(data).AccountStatement;
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

	    /// <summary>
	    /// Returns transactions in selected period
	    /// </summary>
	    public async Task<AccountStatement> PeriodsAsync(TransactionFilter filter)
	    {
		    string url = string.Format(FioUrl.Periods, _authToken, filter.DateFrom, filter.DateTo, Format.Json.ToString().ToLowerInvariant());

		    try
		    {
			    string data = await DownloadDataAsync(url);
			    return JsonConvert.DeserializeObject<RootObject>(data).AccountStatement;
		    }
		    catch (Exception e)
		    {
			    throw new Exception("Data can not be provided", e);
		    }
	    }

		/// <summary>
		/// Returns new transactions from last call
		/// </summary>
		public AccountStatement Last()
        {
            string url = string.Format(FioUrl.Last, _authToken, Format.Json.ToString().ToLowerInvariant());

            try
            {
                string data = DownloadData(url);
                return JsonConvert.DeserializeObject<RootObject>(data).AccountStatement;
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

		/// <summary>
		/// Returns new transactions from last call
		/// </summary>
		public async Task<AccountStatement> LastAsync()
		{
			string url = string.Format(FioUrl.Last, _authToken, Format.Json.ToString().ToLowerInvariant());

			try
			{
				string data = await DownloadDataAsync(url);
				return JsonConvert.DeserializeObject<RootObject>(data).AccountStatement;
			}
			catch (Exception e)
			{
				throw new Exception("Data can not be provided", e);
			}
		}

		/// <summary>
		/// Returns transactions in selected period in requested format
		/// </summary>
		public string Periods(TransactionFilter filter, Format format)
        {
            string url = string.Format(FioUrl.Periods, _authToken, filter.DateFrom, filter.DateTo, format.ToString().ToLowerInvariant());

            try
            {
                return DownloadData(url);
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

	    /// <summary>
	    /// Returns transactions in selected period in requested format
	    /// </summary>
	    public async Task<string> PeriodsAsync(TransactionFilter filter, Format format)
	    {
		    string url = string.Format(FioUrl.Periods, _authToken, filter.DateFrom, filter.DateTo, format.ToString().ToLowerInvariant());

		    try
		    {
				return await DownloadDataAsync(url);
		    }
		    catch (Exception e)
		    {
			    throw new Exception("Data can not be provided", e);
		    }
	    }

		/// <summary>
		/// Returns new transactions from last call in requested format
		/// </summary>
		public string Last(Format format)
        {
            string url = string.Format(FioUrl.Last, _authToken, format.ToString().ToLowerInvariant());

            try
            {
                return DownloadData(url);
            }
            catch (Exception e)
            {
                throw new Exception("Data can not be provided", e);
            }
        }

	    /// <summary>
	    /// Returns new transactions from last call in requested format
	    /// </summary>
	    public async Task<string> LastAsync(Format format)
	    {
		    string url = string.Format(FioUrl.Last, _authToken, format.ToString().ToLowerInvariant());

		    try
		    {
			    return await DownloadDataAsync(url);
		    }
		    catch (Exception e)
		    {
			    throw new Exception("Data can not be provided", e);
		    }
	    }

		/// <summary>
		/// Changes last check date (suitable for Last() method)
		/// </summary>
		public void SetLastDownloadDate(DateTime date)
        {
            string url = string.Format(FioUrl.SetLast, _authToken, date.ToString(Constants.DateFormat));

            try
            {
                DownloadData(url);
            }
            catch (Exception e)
            {
                throw new Exception("Last download date has not been changed", e);
            }
        }

	    /// <summary>
	    /// Changes last check date (suitable for Last() method)
	    /// </summary>
	    public async void SetLastDownloadDateAsync(DateTime date)
	    {
		    string url = string.Format(FioUrl.SetLast, _authToken, date.ToString(Constants.DateFormat));

		    try
		    {
			    await DownloadDataAsync(url);
		    }
		    catch (Exception e)
		    {
			    throw new Exception("Last download date has not been changed", e);
		    }
	    }

		/// <summary>
		/// Downloads data as string from FIO API 
		/// </summary>
		private string DownloadData(string url)
        {
            using(var client = new HttpClient()){
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        return content.ReadAsStringAsync().Result;
                    }
                }
            }
        }

	    private async Task<string> DownloadDataAsync(string url)
	    {
		    using (var client = new HttpClient())
		    {
			    using (HttpResponseMessage response = await client.GetAsync(url))
			    {
				    using (HttpContent content = response.Content)
				    {
					    return await content.ReadAsStringAsync();
				    }
			    }
		    }
		}
    }
}
