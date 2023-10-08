// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int FOLDER_COUNT_MAX = 100;
int FILE_COUNT_MAX = 100;
string[] extensions = new[] { "XLSX", "DOCX", "TXT", "SQL", "PDF", "CS" };

var path = Directory.GetCurrentDirectory();
var random = new Random();

for (var folderCount = 0; folderCount < FOLDER_COUNT_MAX; folderCount++)
{
    var directory = Path.Combine(path, Guid.NewGuid().ToString());
    Directory.CreateDirectory(directory);

    var numberOfFiles = random.Next(FILE_COUNT_MAX);

    for (var fileCount = 0; fileCount < numberOfFiles; fileCount++)
    {
        Console.WriteLine($"Creating {numberOfFiles}");
        var extensionRandomiser = extensions[random.Next(extensions.Length)];

        var newFileName = $"{Guid.NewGuid()}.{extensionRandomiser}";

        using (File.Create(Path.Combine(directory, newFileName)))
        {

        }

        Console.WriteLine($"Create file {newFileName} in directory {directory}");

    }
}