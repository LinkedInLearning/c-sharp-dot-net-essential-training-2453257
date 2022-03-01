// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for parsing numerical data from strings

string[] NumStrs = {"  1 ", " 1.45  ", "-100", "5e+04 "};

int testint;
float testfloat;
bool result;

// The Parse method attempts to parse a string to a number and
// throws an exception if the parse is unsuccessful
foreach (string str in NumStrs) {
    try {
        testfloat = float.Parse(str);
        Console.WriteLine($"Parsed number is {testfloat}");
        testint = int.Parse(str);
        Console.WriteLine($"Parsed number is {testint}");
    }
    catch (FormatException e) {
        Console.WriteLine($"Could not parse '{str}' : {e.Message}");
    }
}

// The TryParse method returns 'true' if the parse is successful
result = int.TryParse(NumStrs[0], out testint);
Console.WriteLine($"{result} -- '{NumStrs[0]}' : {testint}");

result = float.TryParse(NumStrs[1], out testfloat);
Console.WriteLine($"{result} -- '{NumStrs[1]}' : {testfloat}");

result = int.TryParse(NumStrs[2], out testint);
Console.WriteLine($"{result} -- '{NumStrs[2]}' : {testint}");

result = float.TryParse(NumStrs[3], out testfloat);
Console.WriteLine($"{result} -- '{NumStrs[3]}' : {testfloat}");
