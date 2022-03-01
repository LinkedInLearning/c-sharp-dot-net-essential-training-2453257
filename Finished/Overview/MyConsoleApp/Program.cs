// Exercise file for LinkedIn Learning Course .NET Programming with C# by Joe Marini

// The Console object contains functions for writing and reading
// data to and from the command line interface
Console.WriteLine("Hello, World!");

string response;
Console.WriteLine("What's your name?");
response = Console.ReadLine();
Console.WriteLine($"Enjoy the course, {response}");

// Use the platform to get some information about the system
OperatingSystem thisOS = Environment.OSVersion;
Console.WriteLine(thisOS.Platform);
Console.WriteLine(thisOS.VersionString);
