using HelloCicd.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace HelloCicd.Api.Controllers;

/// <summary>
/// Handles hello world requests.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public sealed class HelloController : ControllerBase
{
    private readonly IHelloService _helloService;

    public HelloController(IHelloService helloService)
    {
        _helloService = helloService;
    }

    /// <summary>
    /// Returns a hello world message.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        try
        {
            var response = _helloService.GetHello();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}