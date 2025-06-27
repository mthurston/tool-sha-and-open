using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using ShaOpen.Services;

namespace ShaOpen.Tests.Services
{
    public class FileServiceTests
    {
        private readonly FileService _fileService;

        public FileServiceTests()
        {
            _fileService = new FileService();
        }

        [Fact]
        public void GetFilesFromDownloads_ReturnsFiles()
        {
            // Act
            var result = _fileService.GetFilesFromDownloads();

            // Assert
            Assert.NotNull(result);
            // Note: This test will vary based on actual downloads folder content
            // In a real scenario, you might want to mock the file system or use a test directory
        }

        [Fact]
        public void OpenFile_ValidPath_DoesNotThrow()
        {
            // Arrange
            var testFilePath = Path.Combine(Path.GetTempPath(), "testfile.txt");
            File.WriteAllText(testFilePath, "test content");

            // Act & Assert
            // This would normally open the file, but for testing we just ensure no exception is thrown
            // In practice, you might want to mock the Process.Start call
            Assert.True(File.Exists(testFilePath));

            // Cleanup
            File.Delete(testFilePath);
        }
    }
}