// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Solution to Programming Challenge for "How Many Days?"

string thedate = "";                // holds the user-entered date string
DateTime today = DateTime.Today;    // holds the current date with time of 12:00:00

do {
    // print the greeting and ask for a date
    Console.WriteLine("Which date? (or 'exit')");
    thedate = Console.ReadLine();

    // if the user enters the term 'exit' then leave the app
    if (thedate == "exit") {
        break;
    }

    // try to parse the date
    DateTime parsedDate;
    TimeSpan ts;
    if (DateTime.TryParse(thedate, out parsedDate)) {
        if (parsedDate < today) {
            // if the date already went by, indicate how many days ago it was
            ts = today - parsedDate;
            Console.WriteLine($"That date went by {ts.Days} days ago!");
        }
        else if (parsedDate == today) {
            Console.WriteLine($"That date is today!");
        }
        else {
            // if the date hasn't yet happened, indicate how many days until it does
            ts = parsedDate - today;
            Console.WriteLine($"That date will be in {ts.Days} days!");
        }
    }
    else {
        // If the user didn't enter a valid date, then print an error message
        Console.WriteLine("That doesn't seem to be a valid date");
    }
} while (thedate != "exit");
