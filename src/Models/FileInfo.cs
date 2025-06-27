// This file defines the FileInfo model, which represents information about a file, including its name and SHA.

namespace ShaOpen.Models;

public class FileInfo
{
    public required string FileName { get; set; }
    public required string Sha { get; set; }
}