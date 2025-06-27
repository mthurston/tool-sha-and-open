using System;
using System.IO;
using Xunit;
using ShaOpen.Commands;
using ShaOpen.Services;

namespace ShaOpen.Tests.Commands
{
    public class ShaCommandTests
    {
        [Fact]
        public void ShaCommand_CanBeInstantiated()
        {
            // Arrange
            var fileService = new FileService();
            var shaCalculator = new ShaCalculator();
            var downloadsPath = Path.Combine(Path.GetTempPath(), "test-downloads");
            Directory.CreateDirectory(downloadsPath);

            // Act
            var shaCommand = new ShaCommand(fileService, shaCalculator, downloadsPath);

            // Assert
            Assert.NotNull(shaCommand);
            
            // Cleanup
            Directory.Delete(downloadsPath, true);
        }

        [Fact]
        public void Services_CanBeInstantiated()
        {
            // Arrange & Act
            var fileService = new FileService();
            var shaCalculator = new ShaCalculator();

            // Assert
            Assert.NotNull(fileService);
            Assert.NotNull(shaCalculator);
        }
    }
}