using System;
using FioSdkCsharp;
using FioSdkCsharp.Models;

namespace FioSampleConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApiExplorer explorer = new ApiExplorer("YOUR_TOKEN_MUST_BE_PRESENT_HERE");

            // get new transactions from last check
            AccountStatement newTransactions = explorer.Last();

            // change last check date
            explorer.SetLastDownloadDate(DateTime.UtcNow.AddMonths(-1));

            // get account statement
            AccountStatement statement = explorer.Periods(TransactionFilter.LastMonth());

            // browse transactions
            foreach (var transaction in statement.TransactionList.Transactions)
            {
                Console.WriteLine(transaction + " - " + transaction.Amount.Value);
            }

            // get data in specific format
            string data = explorer.Periods(TransactionFilter.LastDays(10), Format.Html);
        }
    }
}
