// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(".net v = 8");


string response;
Console.WriteLine("What is your name?");
response = Console.ReadLine();
Console.WriteLine($"Your name is:{response}. Engoy the course!");

OperatingSystem thisOs = Environment.OSVersion;
Console.WriteLine(thisOs);
Console.WriteLine(thisOs.Platform);
Console.WriteLine(thisOs.VersionString);