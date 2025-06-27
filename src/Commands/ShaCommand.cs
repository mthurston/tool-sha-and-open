using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using ShaOpen.Services;

namespace ShaOpen.Commands
{
    public class ShaCommand : RootCommand
    {
        private readonly IFileService _fileService;
        private readonly IShaCalculator _shaCalculator;

        public ShaCommand(IFileService fileService, IShaCalculator shaCalculator)
            : base("A tool to find and open files by their SHA")
        {
            _fileService = fileService;
            _shaCalculator = shaCalculator;

            var shaArgument = new Argument<string?>("sha", () => null, "The SHA of the file to open");
            Add(shaArgument);

            this.SetHandler(async (string? sha) =>
            {
                await HandleCommand(sha);
            }, shaArgument);
        }

        private async Task HandleCommand(string? sha)
        {
            if (string.IsNullOrEmpty(sha))
            {
                await ListFiles();
            }
            else
            {
                await OpenFile(sha);
            }
        }

        private Task ListFiles()
        {
            var table = new Table();
            table.AddColumn("File");
            table.AddColumn("SHA");

            var files = _fileService.GetFilesFromDownloads();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var fileSha = _shaCalculator.ComputeSha(file);
                table.AddRow(fileName, fileSha);
            }

            AnsiConsole.Write(table);
            return Task.CompletedTask;
        }

        private Task OpenFile(string sha)
        {
            var files = _fileService.GetFilesFromDownloads();
            var fileToOpen = files.FirstOrDefault(f => _shaCalculator.ComputeSha(f).Equals(sha, StringComparison.OrdinalIgnoreCase));

            if (fileToOpen != null)
            {
                AnsiConsole.WriteLine($"Now opening \"{Path.GetFileName(fileToOpen)}\"");
                _fileService.OpenFile(fileToOpen);
            }
            else
            {
                AnsiConsole.WriteLine("File not found.");
            }
            return Task.CompletedTask;
        }
    }
}