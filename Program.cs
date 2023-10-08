// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.IO;

Console.WriteLine("Hello, World!");
var stopwatch = new Stopwatch();
stopwatch.Start();

const int FOLDER_COUNT_MAX = 100;
const int FILE_COUNT_MAX = 100;
string[] extensions = new[] { "XLSX", "DOCX", "TXT", "SQL", "PDF", "CS" };
int totalFiles = 0;
int totalFolders = 0;


var path = Path.Combine(Directory.GetCurrentDirectory(), "files");

#if DEBUG
// auto cleanup for debugging!
if (Directory.Exists(path))
{
    Directory.Delete(path, true);
}
#endif

var random = new Random();

for (var folderCount = 0; folderCount < FOLDER_COUNT_MAX; folderCount++)
{
    var directory = Directory.CreateDirectory(GenerateFolderPath(path)).ToString();
    totalFolders++;
    CreateFilesForFolder(directory);
}

stopwatch.Stop();
Console.WriteLine($"Created a total of {totalFolders} folders with a combined {totalFiles} files in {stopwatch.Elapsed}");

void CreateFilesForFolder(string folderPath, bool createNested = false)
{
    var nested = random.Next(2) == 0;
    if (nested)
    {
        int nestedFolders = random.Next(0, 15);
        int counter = 0;
        while (counter < nestedFolders)
        {
            var path = CreateDirectory(folderPath);
            GenerateFiles(path, random.Next(FILE_COUNT_MAX));
            counter++;
        }

    }

    else
    {
        GenerateFiles(folderPath, random.Next(FILE_COUNT_MAX));
    }


}

void GenerateFiles(string folderPath, int numberOfFiles)
{
    for (var fileCount = 0; fileCount < numberOfFiles; fileCount++)
    {
        var days = random.Next(1, 100);
        DateTime creationTime = DateTime.Now.AddDays(-random.Next(1, 100)).AddHours(random.Next(1, 100)).AddMinutes(random.Next(1, 100)); // randomise the file creation date anywhere from now to 100 days ago
        var extensionRandomiser = extensions[random.Next(extensions.Length)];

        var newFileName = $"{Guid.NewGuid()}.{extensionRandomiser}";

        using (var file = File.Create(Path.Combine(folderPath, newFileName)))
        {
        }

        var filePath = Path.Combine(folderPath, newFileName);
        FileStream fs = new FileStream(filePath, FileMode.Create);
        fs.Close();

        File.SetCreationTime(filePath, creationTime);

        Console.WriteLine($"Created file {newFileName} in directory {folderPath} with a date of {creationTime}");
        totalFiles++;

    }
}

string GenerateFolderPath(string path)
{
    var newPath = Path.Combine(path, Guid.NewGuid().ToString());
    return newPath.ToString();
}

string CreateDirectory(string name)
{
    totalFolders++;
    return Directory.CreateDirectory(Path.Combine(name, Guid.NewGuid().ToString()).ToString()).ToString();
}