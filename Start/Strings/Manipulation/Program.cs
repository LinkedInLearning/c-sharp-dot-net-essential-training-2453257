// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for manipulating string content

string str1 = "The quick brown fox jumps over the lazy dog.";
string str2 = "This is a string";
string str3 = "THIS is a STRING";
string[] strs = {"one", "two", "three", "four"};

// TODO: Length of a string 
Console.WriteLine(str1.Length);

// TODO: Access individual characters
Console.WriteLine(str1[14]);

// TODO: Iterate over a string like any other sequence of values
foreach (char ch in str1){
    Console.Write(ch);
    if (ch == 'b'){
        Console.WriteLine();
        break;
    }
}

// TODO: String Concatenation         
string outstr;
outstr = String.Concat(strs);
Console.WriteLine(outstr);

// TODO: Joining strings together with Join
outstr = String.Join('.', strs);
Console.WriteLine(outstr);
outstr = String.Join("---", strs);
Console.WriteLine(outstr);

// TODO: String Comparison

// Equals just returns a regular Boolean
bool isEqual = str2.Equals(str3);
Console.WriteLine($"{isEqual}");

// bool isEqual = str2.Equals(str3);
// Console.WriteLine($"{isEqual}");

// Compare will perform an ordinal comparison and return:
// < 0 : first string comes before second in sort order
// 0 : first and second strings are same position in sort order
// > 0 : first string comes after the second in sort order
int result = String.Compare(str2, "This is a String");
Console.WriteLine($"{result}");


// TODO: Replacing content
string result = str1.Replace("fox", "cat");
Console.WriteLine($"{result}");
Console.WriteLine(result);