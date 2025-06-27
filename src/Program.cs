using System;
using System.IO;
using System.Linq;
using Spectre.Console;
using ShaOpen.Services;

namespace ShaOpen;

class Program
{
    static void Main(string[] args)
    {
        var fileService = new FileService();
        var shaCalculator = new ShaCalculator();
        var downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        if (args.Length == 0)
        {
            ListFiles(fileService, shaCalculator, downloadsPath);
        }
        else
        {
            var sha = args[0];
            OpenFile(fileService, shaCalculator, downloadsPath, sha);
        }
    }

    private static void ListFiles(IFileService fileService, IShaCalculator shaCalculator, string downloadsPath)
    {
        var table = new Table();
        table.AddColumn("File");
        table.AddColumn("SHA");

        var files = fileService.GetFilesFromDirectory(downloadsPath);
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var fileSha = shaCalculator.ComputeSha(file);
            
            table.AddRow(fileName, fileSha);
        }

        AnsiConsole.Write(table);
    }

    private static void OpenFile(IFileService fileService, IShaCalculator shaCalculator, string downloadsPath, string sha)
    {
        var files = fileService.GetFilesFromDirectory(downloadsPath);
        var fileToOpen = files.FirstOrDefault(f => shaCalculator.ComputeSha(f).Equals(sha, StringComparison.OrdinalIgnoreCase));

        if (fileToOpen != null)
        {
            AnsiConsole.WriteLine($"Now opening \"{Path.GetFileName(fileToOpen)}\"");
            fileService.OpenFile(fileToOpen);
        }
        else
        {
            AnsiConsole.WriteLine("File not found.");
        }
    }
}