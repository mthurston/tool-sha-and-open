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
        public IEnumerable<string> GetFilesFromDownloads()
        {
            var downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            return Directory.EnumerateFiles(downloadsPath);
        }

        public void OpenFile(string filePath)
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}