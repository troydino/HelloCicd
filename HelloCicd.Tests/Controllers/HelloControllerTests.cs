using System.Net;
using System.Text.Json;
using HelloCicd.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HelloCicd.Tests.Controllers;

public sealed class HelloControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public HelloControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetHello_WhenCalled_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/api/hello");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetHello_WhenCalled_ReturnsJsonContentType()
    {
        // Act
        var response = await _client.GetAsync("/api/hello");

        // Assert
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task GetHello_WhenCalled_ReturnsHelloWorldMessage()
    {
        // Act
        var response = await _client.GetAsync("/api/hello");
        var content = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<HelloResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello, World!", result.Message);
        Assert.NotNull(result.Version);
        Assert.True(result.Timestamp > DateTime.MinValue);
    }
}