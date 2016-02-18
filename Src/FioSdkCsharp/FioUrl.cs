namespace FioSdkCsharp
{
    internal class FioUrl
    {
        /// <summary>
        /// {0} - token
        /// {1} - date from (yyyy-MM-dd)
        /// {2} - date to (yyyy-MM-dd)
        /// {3} - format
        /// </summary>
        public const string Transactions = "https://www.fio.cz/ib_api/rest/periods/{0}/{1}/{2}/transactions.{3}";
    }
}
