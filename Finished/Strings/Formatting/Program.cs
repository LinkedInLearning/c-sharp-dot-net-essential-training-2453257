// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for formatting string content

float f1 = 123.4f;
int i1 = 2000;

// Spacing and Alignment: Indexes
Console.WriteLine("{0,-15} {1,10}", "Float Val", "Int Val");
Console.WriteLine("{0,-15} {1,10}", f1, i1);

// Spacing and Alignment: Interpolation
Console.WriteLine("{0,-15} {1,10}", "Float Val", "Int Val");
Console.WriteLine($"{f1,-15} {i1,10}");
