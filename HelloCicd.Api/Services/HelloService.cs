using HelloCicd.Api.Models;
using System.ComponentModel.Design;

namespace HelloCicd.Api.Services;

/// <summary>
/// Default implementation of <see cref="IHelloService"/>.
/// </summary>
public sealed class HelloService : IHelloService
{
    /// <inheritdoc />
    public HelloResponse GetHello()
    {
        return new HelloResponse("Hello, World!", DateTime.UtcNow);
    }
}