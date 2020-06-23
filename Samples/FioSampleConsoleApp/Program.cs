using System;
using System.Net.Http;
using System.Threading.Tasks;
using FioSdkCsharp;
using FioSdkCsharp.Models;

namespace FioSampleConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // u can use your own httpclient
            HttpClient httpClient = new HttpClient();
            
            ApiExplorer explorer = new ApiExplorer("FIO_TOKEN_HERE", httpClient);

            // get new transactions from last check
            //AccountStatement newTransactions = await explorer.LastAsync();

            // change last check date
            //await explorer.SetLastDownloadDate(DateTime.UtcNow.AddMonths(-1));

            // get account statement
            AccountStatement statement = await explorer.PeriodsAsync(TransactionFilter.LastMonth());

            // browse transactions
            foreach (var transaction in statement.TransactionList.Transactions)
            {
                Console.ForegroundColor = transaction.Amount.Value < 0 ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine(transaction + " - " + transaction.Amount.Value);
            }

            // get data in specific format
            string data = await explorer.PeriodsAsync(TransactionFilter.LastDays(10), Format.Html);
        }
    }
}
