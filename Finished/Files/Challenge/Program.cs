// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Solution for the Files Programming Challenge

// the directory we want to enumerate and results file name
const string folder = "FileCollection";
const string resultsfile = "results.txt";

// Variables to hold the results
long XLSCount = 0, DOCCount = 0, PPTCount = 0;
long XLSSize = 0, DOCSize = 0, PPTSize = 0;
long totalfiles = 0;
long totalsize = 0;

bool IsOfficeFile(string filename) {
    // if the file ends with a known office suffix, return true
    if (filename.EndsWith(".xlsx") || filename.EndsWith(".docx")
        || filename.EndsWith(".pptx"))
        return true;
    return false;
}

// create a DirectoryInfo for the given folder
DirectoryInfo di = new DirectoryInfo(folder);

foreach (FileInfo fi in di.EnumerateFiles()) {
    // Is this an Office file? (XLSX, DOCX, PPTX)
    if (IsOfficeFile(fi.Name)) {
        totalfiles++;
        totalsize += fi.Length;
        if (fi.Name.EndsWith(".xlsx")) {
            XLSCount++;
            XLSSize += fi.Length;
        }
        if (fi.Name.EndsWith(".docx")) {
            DOCCount++;
            DOCSize += fi.Length;
        }
        if (fi.Name.EndsWith(".pptx")) {
            PPTCount++;
            PPTSize += fi.Length;
        }
    }
}

// Output the results
using (StreamWriter sw = File.CreateText(resultsfile)) {
    sw.WriteLine("~~~~ Results ~~~~");
    sw.WriteLine($"Total Files: {totalfiles}");
    sw.WriteLine($"Excel Count: {XLSCount}");
    sw.WriteLine($"Word Count: {DOCCount}");
    sw.WriteLine($"PowerPoint Count: {PPTCount}");
    sw.WriteLine("----");
    sw.WriteLine($"Total Size: {totalsize:N0}");
    sw.WriteLine($"Excel Size: {XLSSize:N0}");
    sw.WriteLine($"Word Size: {DOCSize:N0}");
    sw.WriteLine($"PowerPoint Size: {PPTSize:N0}");
}
