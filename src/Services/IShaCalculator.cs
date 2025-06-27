// This file defines the contract for SHA calculation services, including methods to compute and verify SHA hashes.

namespace ShaOpen.Services;

public interface IShaCalculator
{
    /// <summary>
    /// Computes the SHA hash of a specified file.
    /// </summary>
    /// <param name="filePath">The path of the file to compute the SHA for.</param>
    /// <returns>The computed SHA hash as a string.</returns>
    string ComputeSha(string filePath);

    /// <summary>
    /// Verifies if the computed SHA hash of a specified file matches the provided SHA.
    /// </summary>
    /// <param name="filePath">The path of the file to verify.</param>
    /// <param name="expectedSha">The expected SHA hash to compare against.</param>
    /// <returns>True if the computed SHA matches the expected SHA; otherwise, false.</returns>
    bool VerifySha(string filePath, string expectedSha);
}