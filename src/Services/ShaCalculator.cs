using System;
using System.IO;
using System.Security.Cryptography;

namespace ShaOpen.Services;

public class ShaCalculator : IShaCalculator
{
    public string ComputeSha(string filePath)
    {
        using var sha256 = SHA256.Create();
        using var stream = File.OpenRead(filePath);
        var hash = sha256.ComputeHash(stream);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    public bool VerifySha(string filePath, string expectedSha)
    {
        var computedSha = ComputeSha(filePath);
        return string.Equals(computedSha, expectedSha, StringComparison.OrdinalIgnoreCase);
    }
}