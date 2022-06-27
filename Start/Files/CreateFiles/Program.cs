// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Creating and Deleting Files

const string filename = "TestFile.txt";

// TODO: Create a new file - this will overwrite any existing file
// Use the "using" construct to automatically close the file stream
// using(StreamWriter sw = File.CreateText(filename)){
//     sw.WriteLine("hello!");
// }

// TODO: Determine if a file exists
Console.WriteLine(File.Exists(filename));
if (File.Exists(filename)){
    File.Delete(filename);
}
else{
    using(StreamWriter sw = File.CreateText(filename)){
     sw.WriteLine("hello!");
    }
}
Console.WriteLine(File.Exists(filename));
