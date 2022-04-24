namespace FioSdkCsharp
{
    internal static class FioUrl
    {
        /// <summary>
        /// {0} - token
        /// {1} - date from (yyyy-MM-dd)
        /// {2} - date to (yyyy-MM-dd)
        /// {3} - format
        /// </summary>
        public const string Periods = "https://www.fio.cz/ib_api/rest/periods/{0}/{1}/{2}/transactions.{3}";

        /// <summary>
        /// {0} - token
        /// {1} - format
        /// </summary>
        public const string Last = "https://www.fio.cz/ib_api/rest/last/{0}/transactions.{1}";

        /// <summary>
        /// {0} - token
        /// {1} - date
        /// </summary>
        public const string SetLastDate = "https://www.fio.cz/ib_api/rest/set-last-date/{0}/{1}";

        /// <summary>
        /// {0} - token
        /// {1} - id
        /// </summary>
        public const string SetLastId = "https://www.fio.cz/ib_api/rest/set-last-id/{0}/{1}";

        /// <summary>
        /// {0} - token
        /// {1} - year
        /// {2} - id
        /// {3} - format
        /// </summary>
        public const string Movements = "https://www.fio.cz/ib_api/rest/by-id/{0}/{1}/{2}/transactions.{3}";
    }
}