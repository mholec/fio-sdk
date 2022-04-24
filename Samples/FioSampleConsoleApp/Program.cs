using System;
using System.Net.Http;
using System.Threading.Tasks;
using FioSdkCsharp;
using FioSdkCsharp.Extensions.DependencyInjection;
using FioSdkCsharp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FioSampleConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // with DI support
            IServiceCollection services = new ServiceCollection();
            services.AddFioClient("AUTH_TOKEN");
            var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<IFioClient>();

            // without DI
            using (var httpClient = new HttpClient())
            {
                IFioClient simpleClient = FioClient.Create(httpClient, new FioClientConfiguration()
                {
                    AuthToken = "AUTH_TOKEN"
                });
            }

            // get new transactions from last check
            //AccountStatement newTransactions = await explorer.LastAsync();

            // change last check date
            //await explorer.SetLastDownloadDate(DateTime.UtcNow.AddMonths(-1));

            // get account statement
            AccountStatement statement = await client.PeriodsAsync(TransactionFilter.LastMonth());

            // set own datetime.now
            AccountStatement statementByDate = await client.PeriodsAsync(TransactionFilter.LastDay(DateTime.Now));

            // browse transactions
            foreach (var transaction in statement.TransactionList.Transactions)
            {
                Console.ForegroundColor = transaction.Amount.Value < 0 ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine(transaction + " - " + transaction.Amount.Value);
            }

            // get data in specific format + exception handling demo
            try
            {
                string data = await client.PeriodsAsync(TransactionFilter.LastDays(10), Format.Html);
            }
            catch (FioClientException e)
            {
                Console.WriteLine("FioClient exception", e.Message);
                Console.WriteLine("Inner exception message (HTTP)", e.InnerException?.Message);
            }
        }
    }
}