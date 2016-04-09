using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using FioSdkCsharp;
using FioSdkCsharp.Models;
using System.Diagnostics;

namespace FioWUPUnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            ApiExplorer explorer = new ApiExplorer("YOUR_TOKEN_MUST_BE_PRESENT_HERE");

            // get new transactions from last check
            AccountStatement newTransactions = explorer.LastAsync().Result;

            // browse transactions
            foreach (var transaction in newTransactions.TransactionList.Transactions)
            {
                Debug.WriteLine(transaction + " - " + transaction.Amount.Value);
            }
        }
    }
}
