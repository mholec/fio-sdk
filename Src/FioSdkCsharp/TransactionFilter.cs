using System;

namespace FioSdkCsharp
{
    public class TransactionFilter
    {
        private DateTime _from;
        private DateTime _to;

        public TransactionFilter(DateTime dateFrom, DateTime dateTo)
        {
            _from = dateFrom;
            _to = dateTo;
        }

        public string DateFrom
        {
            get { return _from.ToString("yyyy-MM-yy"); }
        }

        public string DateTo
        {
            get { return _to.ToString("yyyy-MM-yy"); }
        }


        public static TransactionFilter LastDay()
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddDays(-1), now);
        }

        public static TransactionFilter LastWeek()
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddDays(-7), now);
        }

        public static TransactionFilter LastMonth()
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddMonths(-1), now);
        }

        public static TransactionFilter LastYear()
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddYears(-1), now);
        }

        public static TransactionFilter LastDays(int days)
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddDays(-1 * days), now);
        }

        public static TransactionFilter LastWeeks(int weeks)
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddDays(-1 * 7 * weeks), now);
        }

        public static TransactionFilter LastMonths(int months)
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddMonths(-1 * months), now);
        }

        public static TransactionFilter LastYears(int years)
        {
            DateTime now = DateTime.UtcNow;
            return new TransactionFilter(now.AddYears(-1 * years), now);
        }
    }
}
