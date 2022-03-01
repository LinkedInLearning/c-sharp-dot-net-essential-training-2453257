// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Creating and Deleting Directories

const string dirname = "TestDir";

// Create a Directory if it doesn't already exist
if (!Directory.Exists(dirname)) {
    Directory.CreateDirectory(dirname);
}
else {
    Directory.Delete(dirname);
}

// Get the path for the current directory
string curpath = Directory.GetCurrentDirectory();
Console.WriteLine($"Current directory is {curpath}");

// Just like with files, you can retrieve info about a directory
DirectoryInfo di = new DirectoryInfo(curpath);
Console.WriteLine($"{di.Name}");
Console.WriteLine($"{di.Parent}");
Console.WriteLine($"{di.CreationTime}");
Console.WriteLine("---------------");

// Enumerate the contents of directories
Console.WriteLine("Just directories:");
List<string> thedirs = new List<string>(Directory.EnumerateDirectories(curpath));
foreach (string dir in thedirs) {
    Console.WriteLine(dir);
}
Console.WriteLine("---------------");

Console.WriteLine("Just files:");
List<string> thefiles = new List<string>(Directory.EnumerateFiles(curpath));
foreach (string dir in thefiles) {
    Console.WriteLine(dir);
}
Console.WriteLine("---------------");

Console.WriteLine("All directory contents:");
List<string> thecontents = new List<string>(Directory.EnumerateFileSystemEntries(curpath));
foreach (string dir in thecontents) {
    Console.WriteLine(dir);
}
