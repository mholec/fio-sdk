[![NuGet](https://img.shields.io/nuget/v/FioSdk.svg?style=plastic)](https://www.nuget.org/packages/FioSdk)

# FIO Banka Client for <span>C#</span>
This client library make communication with FIO API much easier. 

## Quick start

Examples of how to use Fio Client can be found in the sample project **samples/FioSampleConsoleApp**

**Please note that FIO only allows one API call per 30 seconds.**

### Step 1: Get your access token
At the beginning you must obtain your access token. You can obtain it in your [FIO internetbanking](http://www.fio.cz/ib2/login). Your token must have read access (writing is not required at this moment).

### Step 2: Install Fio Client

Install client via NuGet package

	PM> Install-Package FioSdk

Alternatively, you can use integration package for **Microsoft DI**

	PM> Install-Package FioSdk.Extensions.DependencyInjection

### Step 3: Play with SDK
Once you have your token and client installed, you can use SDK and get information about your statement

	// create FioClient directly
	using(HttpClient httpClient = new HttpClient())
    {
       IFioClient simpleClient = FioClient.Create(httpClient, new FioClientConfiguration()
       {
          AuthToken = "AUTH_TOKEN"
       });
    }

    // OR create FioClient using MSDI
    services.AddFioClient("AUTH_TOKEN");
	
	// get account statement
	AccountStatement statement = client.Periods(TransactionFilter.LastMonth());
	
	// browse transactions
	foreach (var transaction in statement.TransactionList.Transactions)
	{
	    Console.WriteLine(transaction + " - " + transaction.Amount.Value);
	}

#### Example - Choose period

	var statement = client.Periods(TransactionFilter.LastDay());
	var statement = client.Periods(TransactionFilter.LastMonth());

#### Example - Choose exact period
	var statement = client.Periods(TransactionFilter.LastDays(14));
	var statement = client.Periods(TransactionFilter.LastWeeks(8));

#### Example - Get data in specific format

    string html = client.Periods(TransactionFilter.LastDays(10), Format.Html);
    string xml = client.Periods(TransactionFilter.LastDays(10), Format.Xml);
    string csv = client.Periods(TransactionFilter.LastDays(10), Format.Csv);

#### Example - Get new transactions from last download
	var statement = client.Last();

You can change last download date also:

	client.SetLastDownloadDate(DateTime.UtcNow.AddMonths(-1));

## Supported frameworks

- .NET Standard 2.1 + (for version > 3.0)
- .NET Standard 2.0 + (for version < 3.0)


## Changelist

#### Version 3.0.0

Version 3.0.0. contains important breaking changes. Due to using System.Text.Json library target framework has been changed to NET Standard 2.0.

- changed ApiExplorer to IFioClient (and FioClient implementation)
- all methods support async calls only
- cancellation tokens support
- changed target framework to .NET Standard 2.1
- implemented System.Text.Json with internal serializer config
- possibility to pass own HttpClient to FioClient
- common code cleanup

#### Version 2.1.0

- all methods support async calls


#### Version 2.0.0

- added support for .NET Standard 1.3