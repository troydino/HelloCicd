using HelloCicd.Api.Services;

namespace HelloCicd.Tests.Services;

public sealed class HelloServiceTests
{
    private readonly HelloService _sut = new();

    [Fact]
    public void GetHello_WhenCalled_ReturnsHelloWorldMessage()
    {
        // Arrange - done in constructor

        // Act
        var result = _sut.GetHello();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello, World!", result.Message);
    }

    [Fact]
    public void GetHello_WhenCalled_ReturnsTimestamp()
    {
        // Arrange
        var before = DateTime.UtcNow;

        // Act
        var result = _sut.GetHello();

        // Assert
        Assert.True(result.Timestamp >= before);
        Assert.True(result.Timestamp <= DateTime.UtcNow);
    }
}