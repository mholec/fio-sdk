using System;

namespace FioSdkCsharp
{
    public class TransactionFilter
    {
        private readonly DateTime _from;
        private readonly DateTime _to;

        private TransactionFilter(DateTime from, DateTime to)
        {
            _from = from;
            _to = to;
        }

        public string DateFrom => _from.ToString(Constants.DateFormat);

	    public string DateTo => _to.ToString(Constants.DateFormat);

	    public static TransactionFilter LastDay(DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddDays(-1), now.Value);
        }

        public static TransactionFilter LastWeek(DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddDays(-7), now.Value);
        }

        public static TransactionFilter LastMonth(DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddMonths(-1), now.Value);
        }

        public static TransactionFilter LastYear(DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddYears(-1), now.Value);
        }

        public static TransactionFilter LastDays(int days, DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddDays(-1 * days), now.Value);
        }

        public static TransactionFilter LastWeeks(int weeks, DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddDays(-1 * 7 * weeks), now.Value);
        }

        public static TransactionFilter LastMonths(int months, DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddMonths(-1 * months), now.Value);
        }

        public static TransactionFilter LastYears(int years, DateTime? now = null)
        {
            if (now == null)
            {
                now = DateTime.UtcNow;
            }

            return new TransactionFilter(now.Value.AddYears(-1 * years), now.Value);
        }
    }
}