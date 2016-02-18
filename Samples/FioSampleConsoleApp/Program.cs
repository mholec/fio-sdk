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

            // get account statement
            AccountStatement statement = explorer.Account(TransactionFilter.LastMonth());

            // browse transactions
            foreach (var transaction in statement.TransactionList.Transactions)
            {
                Console.WriteLine(transaction + " - " + transaction.Amount.Value);
            }

            // get data in specific format
            // !!! be aware of attacking fio endpoint, you can call their API again after 30 seconds
            string data = explorer.Account(TransactionFilter.LastDays(10), Format.Html);
        }
    }
}
