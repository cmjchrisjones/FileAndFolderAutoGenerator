using System.Diagnostics;

var stopwatch = new Stopwatch();
stopwatch.Start();

const string INVALID_INPUT = "Input not valid: defaulting...";
string[] extensions = new[] { "XLSX", "DOCX", "TXT", "SQL", "PDF", "CS" };
int totalFiles = 0, totalFolders = 0, totalRootFolders = 0, foldersThatAreNested = 0;
int FOLDERS = 0, FILES = 0;
var random = new Random();

var path = Path.Combine(Directory.GetCurrentDirectory(), "files");

Console.Write("How many root folders would you like to create? ");
ProcessInput(Console.ReadLine() ?? "", ref FOLDERS);

Console.Write("What is the maximum amount of files you like to create per folder? ");
ProcessInput(Console.ReadLine() ?? "", ref FILES);

Console.Write("Path where you want to generate the files? ");

Console.WriteLine($"You have selected to create {FOLDERS} folders with a maximum number {FILES} files in each.");

#if DEBUG
// auto cleanup for debugging!

if (Directory.Exists(path))
{
    Directory.Delete(path, true);
}
#endif

for (var folderCount = 0; folderCount < FOLDERS; folderCount++)
{
    var directory = Directory.CreateDirectory(GenerateFolderPath(path)).ToString();
    totalFolders++;
    CreateFilesForFolder(directory);
}

stopwatch.Stop();
Console.WriteLine($"Created a total of {totalFolders} folders ({foldersThatAreNested} nested, {totalRootFolders} root folders) with a combined {totalFiles} files in {stopwatch.Elapsed}");

void CreateFilesForFolder(string folderPath, bool createNested = false)
{
    var nested = random.Next(2) == 0;
    totalRootFolders++;
    if (nested)
    {
        int nestedFolders = random.Next(0, 15);
        int counter = 0;
        while (counter < nestedFolders)
        {
            var path = CreateDirectory(folderPath);
            GenerateFiles(path, random.Next(FILES));
            foldersThatAreNested++;
            counter++;
        }
    }
    else
    {
        GenerateFiles(folderPath, random.Next(FILES));
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

void ProcessInput(string input, ref int output)
{
    if (int.TryParse(input, out var number))
    {
        output = number;
    }
    else
    {
        Console.WriteLine(INVALID_INPUT);
        output = 100;
    };
}