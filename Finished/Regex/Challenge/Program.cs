// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Solution to programming challenge for "Reverse Date Formats"
using System.Text.RegularExpressions;

// Takes a date in the form mm/dd/yyyy and returns the date
// formatted as yyyy-mm-dd. Month and day can be 1 or 2 digits,
// and the year can be 2 or 4 digits
static string ReverseDateFormat(string sourceDate) {
    const int TIMEOUT = 1000;
    try {
        return Regex.Replace(sourceDate,
               @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$",
              "${year}-${mon}-${day}", RegexOptions.None,
              TimeSpan.FromMilliseconds(TIMEOUT));
    }
    catch (RegexMatchTimeoutException) {
        return sourceDate;
    }
}

do {
    // Ask the user for the date to convert
    Console.WriteLine("Date to Convert? (Use mm/dd/yyyy, or 'exit' to quit)");
    string inputStr = Console.ReadLine();

    if (inputStr == "exit") {
        break;
    }

    // Make sure it's a valid date before we try to convert it
    DateTime result;
    if (DateTime.TryParse(inputStr, out result)) {
        string reverseDate = ReverseDateFormat(inputStr);
        Console.WriteLine($"The reversed format is {reverseDate}");
    }
    else {
        Console.WriteLine("That's not a valid date, try again");
    }
} while(true);
