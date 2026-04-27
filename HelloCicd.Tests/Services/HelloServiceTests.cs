using HelloCicd.Api.Services;
using Microsoft.Extensions.Configuration;

namespace HelloCicd.Tests.Services;

public sealed class HelloServiceTests
{
    private readonly HelloService _sut;

    public HelloServiceTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "AppEnvironment", "Test" }
            })
            .Build();

        _sut = new HelloService(configuration);
    }

    [Fact]
    public void GetHello_WhenCalled_ReturnsHelloWorldMessage()
    {
        // Act
        var result = _sut.GetHello();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello, World!", result.Message);
    }

    [Fact]
    public void GetHello_WhenCalled_ReturnsVersion()
    {
        // Act
        var result = _sut.GetHello();

        // Assert
        Assert.NotNull(result.Version);
        Assert.NotEmpty(result.Version);
    }

    [Fact]
    public void GetHello_WhenCalled_ReturnsAppEnvironment()
    {
        // Act
        var result = _sut.GetHello();

        // Assert
        Assert.Equal("Test", result.AppEnvironment);
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