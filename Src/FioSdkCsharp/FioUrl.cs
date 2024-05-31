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
        public const string Periods = "https://fioapi.fio.cz/v1/rest/periods/{0}/{1}/{2}/transactions.{3}";

        /// <summary>
        /// {0} - token
        /// {1} - format
        /// </summary>
        public const string Last = "https://fioapi.fio.cz/v1/rest/last/{0}/transactions.{1}";

        /// <summary>
        /// {0} - token
        /// {1} - date
        /// </summary>
        public const string SetLastDate = "https://fioapi.fio.cz/v1/rest/set-last-date/{0}/{1}";

        /// <summary>
        /// {0} - token
        /// {1} - id
        /// </summary>
        public const string SetLastId = "https://fioapi.fio.cz/v1/rest/set-last-id/{0}/{1}";

        /// <summary>
        /// {0} - token
        /// {1} - year
        /// {2} - id
        /// {3} - format
        /// </summary>
        public const string Movements = "https://fioapi.fio.cz/v1/rest/by-id/{0}/{1}/{2}/transactions.{3}";
    }
}