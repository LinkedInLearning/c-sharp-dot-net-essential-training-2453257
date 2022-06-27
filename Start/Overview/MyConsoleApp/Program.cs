
// See https://aka.ms/new-console-template for more information
string response;
Console.WriteLine("Hello, World!");
Console.WriteLine("Name?");
response = Console.ReadLine();
Console.WriteLine($"Enjoy, {response}");

OperatingSystem thisOS = Environment.OSVersion;
Console.WriteLine(thisOS.Platform);
Console.WriteLine(thisOS.VersionString);