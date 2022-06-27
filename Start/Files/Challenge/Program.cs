// See https://aka.ms/new-console-template for more information

const string folder = "FileCollection";
const string res = "results.txt";

long xlsc = 0, docc = 0, pptc = 0;
long xlss = 0, docs = 0, ppts = 0;
long filec = 0;
long files = 0;

DirectoryInfo di = new DirectoryInfo(folder);

foreach (FileInfo fi in di.EnumerateFiles()){
    if (fi.Name.EndsWith(".xlsx")){
        filec++;
        files += fi.Length;
        xlsc++;
        xlss += fi.Length;
    }
    else if(fi.Name.EndsWith(".docx")){
        filec++;
        files += fi.Length;
        docc++;
        docs += fi.Length;
    }
    else if(fi.Name.EndsWith(".pptx")){
        filec++;
        files += fi.Length;
        pptc++;
        ppts += fi.Length;
    }
    
}

using (StreamWriter sw = File.CreateText(res)){
    sw.WriteLine("Results");
    sw.WriteLine($"Total Files : {filec}");
    sw.WriteLine($"excel files: {xlsc}");
    sw.WriteLine($"Word files : {docc}");
    sw.WriteLine($"ppt Files : {pptc}");
    sw.WriteLine($"Total sixe : {files}");
    sw.WriteLine($"excel size : {xlss}");
    sw.WriteLine($"word size : {docs}");
    sw.WriteLine($"ppt size : {ppts}");

}