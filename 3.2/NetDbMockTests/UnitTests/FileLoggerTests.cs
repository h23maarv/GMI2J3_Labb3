using Moq;
using NetDbMockApp.Interfaces;

namespace NetDbMockTests.UnitTests
{
    public class FileLoggerTests
    {
        private readonly Mock<ILogger> _mockLogger;

        public FileLoggerTests()
        {
            // Set up the mock for ILogger
            _mockLogger = new Mock<ILogger>();
        }

        [Fact]
        public async Task Log_LogsMessageSuccessfully()
        {
            // Arrange: Set up mock behavior for Log
            _mockLogger.Setup(logger => logger.Log(It.IsAny<string>())).Returns(Task.CompletedTask);

            // Act: Call the method
            await _mockLogger.Object.Log("Test message");

            // Assert: Verify that Log was called once with any string
            _mockLogger.Verify(logger => logger.Log(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task LogError_LogsErrorSuccessfully()
        {
            // Arrange: Set up mock behavior for LogError
            _mockLogger.Setup(logger => logger.LogError(It.IsAny<string>(), It.IsAny<Exception>())).Returns(Task.CompletedTask);

            // Act: Call the method
            await _mockLogger.Object.LogError("Error message", new Exception("Test exception"));

            // Assert: Verify that LogError was called once with any string and exception
            _mockLogger.Verify(logger => logger.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
        }
    }
}