using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;
using ShaOpen.Services;

namespace ShaOpen.Tests.Services
{
    public class ShaCalculatorTests
    {
        private readonly IShaCalculator _shaCalculator;

        public ShaCalculatorTests()
        {
            _shaCalculator = new ShaCalculator();
        }

        [Fact]
        public void CalculateSha_ShouldReturnCorrectSha_ForValidFile()
        {
            // Arrange
            var testFilePath = Path.Combine(Path.GetTempPath(), $"testfile_{Guid.NewGuid()}.txt");
            File.WriteAllText(testFilePath, "Test content");

            try
            {
                // Act
                var sha = _shaCalculator.ComputeSha(testFilePath);

                // Assert
                using (var sha256 = SHA256.Create())
                {
                    using var stream = File.OpenRead(testFilePath);
                    var expectedSha = BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                    Assert.Equal(expectedSha, sha);
                }
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }

        [Fact]
        public void VerifySha_ShouldReturnTrue_ForMatchingSha()
        {
            // Arrange
            var testFilePath = Path.Combine(Path.GetTempPath(), $"testfile_{Guid.NewGuid()}.txt");
            File.WriteAllText(testFilePath, "Test content");

            try
            {
                var sha = _shaCalculator.ComputeSha(testFilePath);

                // Act
                var result = _shaCalculator.VerifySha(testFilePath, sha);

                // Assert
                Assert.True(result);
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }

        [Fact]
        public void VerifySha_ShouldReturnFalse_ForNonMatchingSha()
        {
            // Arrange
            var testFilePath = Path.Combine(Path.GetTempPath(), $"testfile_{Guid.NewGuid()}.txt");
            File.WriteAllText(testFilePath, "Test content");

            try
            {
                var sha = "non-matching-sha";

                // Act
                var result = _shaCalculator.VerifySha(testFilePath, sha);

                // Assert
                Assert.False(result);
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }
    }
}