using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ShaOpen.Services
{
    public class FileService : IFileService
    {
        public IEnumerable<string> GetFilesFromDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
            }
            
            return Directory.EnumerateFiles(directoryPath);
        }

        public void OpenFile(string filePath)
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}