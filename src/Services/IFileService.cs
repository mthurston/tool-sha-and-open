// IFileService.cs
using System.Collections.Generic;

namespace ShaOpen.Services
{
    public interface IFileService
    {
        IEnumerable<string> GetFilesFromDownloads();
        void OpenFile(string filePath);
    }
}