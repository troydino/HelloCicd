using HelloCicd.Api.Models;

namespace HelloCicd.Api.Services;

/// <summary>
/// Provides hello world operations.
/// </summary>
public interface IHelloService
{
    /// <summary>
    /// Returns a hello world response.
    /// </summary>
    HelloResponse GetHello();
}