// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for using Regex to find patterns
using System.Text.RegularExpressions;

string teststr1 = "The quick brown Fox jumps over the lazy Dog";
string teststr2 = "the quick brown fox jumps over the lazy dog";

// TODO: The IsMatch function is used to determine if the content of a string
// results in a match with the given Regex
Regex Capwords = new Regex(@"[A-Z]\w+");
// Console.WriteLine(Capwords.IsMatch(teststr1));
// Console.WriteLine(Capwords.IsMatch(teststr2));

// // TODO: The RegexOptions argument can be used to perform
// // case-insensitive searches
// Regex NoCase = new Regex(@"fox", RegexOptions.IgnoreCase);
// Console.WriteLine(NoCase.IsMatch(teststr1));

// Use the Match and Matches methods to get information about
// specific Regex matches for a given pattern

// TODO: The Match method returns a single match at a time
Match m = Capwords.Match(teststr1);
while (m.Success){
    Console.WriteLine($"'{m.Value}' found at position {m.Index}");
    m = m.NextMatch();
}

// TODO: The Matches method returns a collection of Match objects
MatchCollection mc = Capwords.Matches(teststr1);
Console.WriteLine($"Found {mc.Count} matches:");
foreach (Match match in mc){
    Console.WriteLine($"'{match.Value}' found at position {match.Index}");
}
