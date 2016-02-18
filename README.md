# FIO Banka SDK for Csharp
**The SDK works with fio API service**. At the present time you can get your bank statement in various data format.

## Nuget

You can install SDK for FIO using the NuGet

	PM> Install-Package FioSdk

## Quick start
You can find examples how to use this SDK in the project **samples/FioSampleConsoleApp**

Notice, that you can call up API every 30 seconds.

### Step 1: Get your access token
At the beginning you must obtain your access token. You can obtain it in your [FIO internetbanking](http://www.fio.cz/ib2/login). Your token must have read access (writing is not required at this moment).

### Step 2: Play with SDK
Once you have your token, you can use SDK and get information about your statement

	// create your API explorer
    ApiExplorer explorer = new ApiExplorer("YOUR_TOKEN_MUST_BE_PRESENT_HERE");

    // get account statement
    AccountStatement statement = explorer.Account(TransactionFilter.LastMonth());

    // browse transactions
    foreach (var transaction in statement.TransactionList.Transactions)
    {
        Console.WriteLine(transaction + " - " + transaction.Amount.Value);
    }

#### Example - Choose period

	var statement = explorer.Account(TransactionFilter.LastDay());
	var statement = explorer.Account(TransactionFilter.LastMonth());

#### Example - Choose exact period
	var statement = explorer.Account(TransactionFilter.LastDays(14));
	var statement = explorer.Account(TransactionFilter.LastWeeks(8));

#### Example - Get data in specific format

    string html = explorer.Account(TransactionFilter.LastDays(10), Format.Html);
	string xml = explorer.Account(TransactionFilter.LastDays(10), Format.Xml);
	string csv = explorer.Account(TransactionFilter.LastDays(10), Format.Csv);

## Supported frameworks

- .NET 4.5
- .NET 4.5.1
- .NET 4.5.2
- .NET 4.6