using HelloCicd.Api.Models;
using System.Reflection;

namespace HelloCicd.Api.Services;

/// <summary>
/// Default implementation of <see cref="IHelloService"/>.
/// </summary>
public sealed class HelloService : IHelloService
{
    /// <inheritdoc />
    public HelloResponse GetHello()
    {
        var version = Assembly.GetExecutingAssembly()
            .GetName()
            .Version?
            .ToString() ?? "unknown";

        return new HelloResponse("Hello, World!", version, DateTime.UtcNow);
    }
}