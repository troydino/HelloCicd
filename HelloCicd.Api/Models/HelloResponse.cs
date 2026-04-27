namespace HelloCicd.Api.Models;

/// <summary>
/// Represents the response from the Hello endpoint.
/// </summary>
public sealed record HelloResponse(string Message, string Version, DateTime Timestamp);