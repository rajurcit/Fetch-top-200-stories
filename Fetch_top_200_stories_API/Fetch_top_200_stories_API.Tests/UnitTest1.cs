using Moq;
using StoryService;
using System.Threading.Tasks;
using Xunit;

namespace Fetch_top_200_stories_API.Tests;

public class UnitTest1
{
    private readonly Mock<IStoryService> _mockService;

    public UnitTest1()
    {
        _mockService = new Mock<IStoryService>();
    }


    [Fact]
    public async Task Test1()
    {
        // Arrange
        var expectedContent = "Expected content from the service";
        _mockService.Setup(service => service.GetStoryList())
                    .ReturnsAsync(expectedContent);

        // Act
        var actualResult = await _mockService.Object.GetStoryList();

        // Assert
        Assert.Equal(expectedContent, actualResult);
    }
}