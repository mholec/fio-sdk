using System;
using System.Threading;
using System.Threading.Tasks;
using FioSdkCsharp.Models;

namespace FioSdkCsharp
{
    public interface IFioClient
    {
        /// <summary>
        /// Returns transactions in selected period
        /// </summary>
        Task<AccountStatement> PeriodsAsync(TransactionFilter filter, CancellationToken ctx = new CancellationToken());

        /// <summary>
        /// Returns transactions in selected period in requested format
        /// </summary>
        Task<string> PeriodsAsync(TransactionFilter filter, Format format, CancellationToken ctx = new CancellationToken());

        /// <summary>
        /// Returns new transactions from last call
        /// </summary>
        Task<AccountStatement> LastAsync(CancellationToken ctx = new CancellationToken());

        /// <summary>
        /// Returns new transactions from last call in requested format
        /// </summary>
        Task<string> LastAsync(Format format, CancellationToken ctx = new CancellationToken());

        /// <summary>
        /// Changes last check date (suitable for Last() method)
        /// </summary>
        Task SetLastDownloadDateAsync(DateTime date, CancellationToken ctx = new CancellationToken());

        /// <summary>
        /// Changes last check date (suitable for Last() method)
        /// </summary>
        Task SetLastDownloadIdAsync(long id, CancellationToken ctx = new CancellationToken());
    }
}