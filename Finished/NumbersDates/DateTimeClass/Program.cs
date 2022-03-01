// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for working with Dates and Times

// Use DateTime.Now property to get the current date and time
DateTime now = DateTime.Now;
Console.WriteLine(now);

// DateTime.Today gets just the current date with time set to 12:00:00 AM
DateTime today = DateTime.Today;
Console.WriteLine(today);

// DateOnly and TimeOnly represent just dates and times
DateOnly dt = DateOnly.FromDateTime(DateTime.Now);
TimeOnly tm = TimeOnly.FromDateTime(DateTime.Now);
Console.WriteLine(dt);
Console.WriteLine(tm);

// Dates have properties that can be inspected
Console.WriteLine(today.DayOfWeek);
Console.WriteLine(today.DayOfYear);

// Dates also have methods to change their values
now = now.AddDays(5);
now = now.AddHours(9);
now = now.AddMonths(1);
Console.WriteLine(now);

// The TimeSpan class represents a duration of time
DateTime AprilFools = new DateTime(now.Year, 4, 1);
DateTime NewYears = new DateTime(now.Year, 1, 1);
TimeSpan interval = AprilFools - NewYears;
Console.WriteLine(interval);

// Dates can be compared using regular operators
Console.WriteLine($"{NewYears < AprilFools}");
Console.WriteLine($"{NewYears > AprilFools}");
