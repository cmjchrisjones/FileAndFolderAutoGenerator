// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int FOLDER_COUNT_MAX = 100;
int FILE_COUNT_MAX = 100;
string[] extensions = new[] { "XLSX", "DOCX", "TXT", "SQL" };

var path = Directory.GetCurrentDirectory();

for (var folderCount = 0; folderCount < FOLDER_COUNT_MAX; folderCount++)
{
    var directory = Path.Combine(path, Guid.NewGuid().ToString());
    Directory.CreateDirectory(directory);

    var numberOfFiles = new Random().Next(FILE_COUNT_MAX);

    for (var fileCount = 0; fileCount < numberOfFiles; fileCount++)
    {
        Console.WriteLine($"Creating {numberOfFiles}");
        var fileName = Guid.NewGuid().ToString();
        var extenionRandomiser = new Random().Next(extensions.Length);
        var extension = extensions[extenionRandomiser];

        var newFileName = $"{fileName}.{extension}";

        File.Create(Path.Combine(directory, newFileName));

        Console.WriteLine($"Create file {newFileName} in directory {directory}");

    }
}