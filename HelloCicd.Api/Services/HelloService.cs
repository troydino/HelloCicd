using HelloCicd.Api.Models;
using System.Reflection;

namespace HelloCicd.Api.Services;

/// <summary>
/// Default implementation of <see cref="IHelloService"/>.
/// </summary>
public sealed class HelloService : IHelloService
{
    private readonly IConfiguration _configuration;

    public HelloService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <inheritdoc />
    public HelloResponse GetHello()
    {
        try
        {
            var version = Assembly.GetExecutingAssembly()
                .GetName()
                .Version?
                .ToString() ?? "unknown";

            var appEnvironment = _configuration["AppEnvironment"] ?? "unknown";

            return new HelloResponse("Hello, World!", version, appEnvironment, DateTime.UtcNow);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to build hello response.", ex);
        }
    }
}