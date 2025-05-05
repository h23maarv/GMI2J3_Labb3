using Moq;
using NetDbMockApp.Interfaces;

namespace NetDbMockTests.UnitTests
{
    public class NetworkClientTests
    {
        private readonly Mock<INetworkClient> _mockNetworkClient;

        public NetworkClientTests()
        {
            // Set up the mock for INetworkClient
            _mockNetworkClient = new Mock<INetworkClient>();
        }

        [Fact]
        public async Task GetAsync_ReturnsMockedResponse()
        {
            // Arrange: Set up mock behavior for GetAsync
            _mockNetworkClient.Setup(nc => nc.GetAsync(It.IsAny<string>())).ReturnsAsync("Mocked response");

            // Act: Call the method
            var result = await _mockNetworkClient.Object.GetAsync("http://mockurl.com");

            // Assert: Verify the result
            Assert.Equal("Mocked response", result);
        }

        [Fact]
        public async Task PostAsync_ReturnsTrue()
        {
            // Arrange: Set up mock to simulate successful POST
            _mockNetworkClient
                .Setup(nc => nc.PostAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            // Act: Call the method
            var result = await _mockNetworkClient.Object.PostAsync("http://mockurl.com/", "Test payload");

            // Assert: Verify it returned true
            Assert.True(result);
        }

        [Fact]
        public async Task IsNetworkAvailableAsync_ReturnsTrue()
        {
            // Arrange: Set up mock behavior for IsNetworkAvailableAsync
            _mockNetworkClient.Setup(nc => nc.IsNetworkAvailableAsync()).ReturnsAsync(true);

            // Act: Call the method
            var result = await _mockNetworkClient.Object.IsNetworkAvailableAsync();

            // Assert: Verify the result
            Assert.True(result);
        }
    }
}