using Moq;
using NetDbMockApp.Interfaces;

namespace NetDbMockTests.UnitTests
{
    public class DataServiceTests
    {
        private readonly Mock<IDataService> _mockDataService;

        public DataServiceTests()
        {
            // Set up the mock for IDataService
            _mockDataService = new Mock<IDataService>();
        }

        [Fact]
        public async Task GetDataAsync_ReturnsMockData()
        {
            // Arrange: Set up mock behavior for GetDataAsync
            _mockDataService.Setup(ds => ds.GetDataAsync<string>("123")).ReturnsAsync("TestData");

            // Act: Call the method
            var result = await _mockDataService.Object.GetDataAsync<string>("123");

            // Assert: Verify the result
            Assert.Equal("TestData", result);
        }

        [Fact]
        public async Task SaveDataAsync_ReturnsTrue()
        {
            // Arrange: Set up mock behavior for SaveDataAsync
            _mockDataService.Setup(ds => ds.SaveDataAsync(It.IsAny<object>())).ReturnsAsync(true);

            // Act: Call the method
            var result = await _mockDataService.Object.SaveDataAsync(new object());

            // Assert: Verify the result
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteDataAsync_ReturnsTrue()
        {
            // Arrange: Set up mock behavior for DeleteDataAsync
            _mockDataService.Setup(ds => ds.DeleteDataAsync("123")).ReturnsAsync(true);

            // Act: Call the method
            var result = await _mockDataService.Object.DeleteDataAsync("123");

            // Assert: Verify the result
            Assert.True(result);
        }
    }
}