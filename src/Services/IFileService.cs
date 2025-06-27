// IFileService.cs
using System.Collections.Generic;

namespace ShaOpen.Services
{
    public interface IFileService
    {
        IEnumerable<string> GetFilesFromDirectory(string directoryPath);
        void OpenFile(string filePath);
    }
}