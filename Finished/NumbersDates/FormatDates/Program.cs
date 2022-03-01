// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for formatting date information
using System.Globalization;

// Define a date
DateTime AprFools = new DateTime(2025, 4, 1, 13, 23, 30);

// 'd' Short date: mm/dd/yyyy (or dd/mm depending on locale)
Console.WriteLine($"{AprFools:d}");
// 'D' Full date: mm/dd/yyyy (or dd/mm depending on locale)
Console.WriteLine($"{AprFools:D}");

// 'f' Full date, short time
Console.WriteLine($"{AprFools:f}");
// 'F' Full date, long time
Console.WriteLine($"{AprFools:F}");

// 'g' General date and time
Console.WriteLine($"{AprFools:g}");
// 'G' General date and time
Console.WriteLine($"{AprFools:G}");

// Format using a specific CultureInfo
Console.WriteLine(AprFools.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")));

// Defining custom date and time formats
Console.WriteLine($"{AprFools:dddd, MMMM d yyyy}");
Console.WriteLine($"{AprFools:ddd h:mm:ss tt}");
Console.WriteLine($"{AprFools:MMM d yyyy}");
