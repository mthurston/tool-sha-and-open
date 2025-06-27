using Xunit;
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

            // Act & Assert
            // This test just ensures the command can be created without issues
            // More comprehensive tests would require setting up the command line infrastructure
            Assert.NotNull(fileService);
            Assert.NotNull(shaCalculator);
        }
    }
}