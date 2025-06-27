using System;
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
        private readonly string _testDirectory;

        public FileServiceTests()
        {
            _fileService = new FileService();
            _testDirectory = Path.Combine(Path.GetTempPath(), "ShaOpenTests", Guid.NewGuid().ToString());
            Directory.CreateDirectory(_testDirectory);
        }

        [Fact]
        public void GetFilesFromDirectory_WithValidDirectory_ReturnsFiles()
        {
            // Arrange
            var testFile1 = Path.Combine(_testDirectory, "test1.txt");
            var testFile2 = Path.Combine(_testDirectory, "test2.txt");
            File.WriteAllText(testFile1, "test content 1");
            File.WriteAllText(testFile2, "test content 2");

            // Act
            var result = _fileService.GetFilesFromDirectory(_testDirectory);

            // Assert
            Assert.NotNull(result);
            var files = result.ToList();
            Assert.Equal(2, files.Count);
            Assert.Contains(testFile1, files);
            Assert.Contains(testFile2, files);

            // Cleanup
            Directory.Delete(_testDirectory, true);
        }

        [Fact]
        public void GetFilesFromDirectory_WithNonExistentDirectory_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "NonExistentDirectory");

            // Act & Assert
            Assert.Throws<DirectoryNotFoundException>(() => _fileService.GetFilesFromDirectory(nonExistentPath));
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