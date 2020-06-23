[![Build status](https://mholec.visualstudio.com/DEV/_apis/build/status/FioSDK)](https://mholec.visualstudio.com/DEV/_build/latest?definitionId=42)
[![Release status](https://mholec.vsrm.visualstudio.com/_apis/public/Release/badge/be71d668-1b9d-4604-ad78-f5d8d1f2194e/10/14)](https://mholec.vsrm.visualstudio.com/_apis/public/Release/badge/be71d668-1b9d-4604-ad78-f5d8d1f2194e/10/14)
[![NuGet](https://img.shields.io/nuget/v/FioSdk.svg?style=plastic)](https://www.nuget.org/packages/FioSdk)

# FIO Banka SDK for <span>C#</span>
This SDK make communication with FIO API much easier. At the present time you can get your bank statement in various data format.

## Nuget

You can install SDK for FIO using the NuGet

	PM> Install-Package FioSdk

Version 3.0.0. contains important breaking changes. Due to using System.Text.Json library target framework has been changed to NET Standard 2.0.


#### Version 3.0.0

- all methods support async calls only
- cancellation tokens support
- changed target framework to .NET Standard 2.0
- implemented System.Text.Json instead of Newtonsoft.Json
- possibility to pass own HttpClient to ApiExplorer
- common code cleanup

#### Version 2.1.0

- all methods support async calls


#### Version 2.0.0

- added support for .NET Standard 1.3


## Quick start

You can find examples how to use this SDK in the project **samples/FioSampleConsoleApp**

Notice, that you can call up API every 30 seconds.

### Step 1: Get your access token
At the beginning you must obtain your access token. You can obtain it in your [FIO internetbanking](http://www.fio.cz/ib2/login). Your token must have read access (writing is not required at this moment).

### Step 2: Play with SDK
Once you have your token, you can use SDK and get information about your statement

	// create your API explorer
	HttpClient optionalHc = new HttpClient();
	ApiExplorer explorer = new ApiExplorer("YOUR_TOKEN_MUST_BE_PRESENT_HERE", optionalHc);
	
	// get account statement
	AccountStatement statement = explorer.Periods(TransactionFilter.LastMonth());
	
	// browse transactions
	foreach (var transaction in statement.TransactionList.Transactions)
	{
	    Console.WriteLine(transaction + " - " + transaction.Amount.Value);
	}

#### Example - Choose period

	var statement = explorer.Periods(TransactionFilter.LastDay());
	var statement = explorer.Periods(TransactionFilter.LastMonth());

#### Example - Choose exact period
	var statement = explorer.Periods(TransactionFilter.LastDays(14));
	var statement = explorer.Periods(TransactionFilter.LastWeeks(8));

#### Example - Get data in specific format

    string html = explorer.Periods(TransactionFilter.LastDays(10), Format.Html);
    string xml = explorer.Periods(TransactionFilter.LastDays(10), Format.Xml);
    string csv = explorer.Periods(TransactionFilter.LastDays(10), Format.Csv);

#### Example - Get new transactions from last download
	var statement = explorer.Last();

You can change last download date also:

	explorer.SetLastDownloadDate(DateTime.UtcNow.AddMonths(-1));

## Supported frameworks

- .NET Standard 2.0 +
