using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Paredev.Identity.Application.Models;

namespace Paredev.Identity.Application.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IIdentityServerInteractionService _interactionService;
    private readonly IWebHostEnvironment _environment;

    public AuthenticationController(IIdentityServerInteractionService interactionService,
        IWebHostEnvironment environment)
    {
        _interactionService = interactionService;
        _environment = environment;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var context = await _interactionService.GetAuthorizationContextAsync(request.RedirectUrl);
        // var user = 

        return Unauthorized();
    }

    [HttpGet]
    public async Task<IActionResult> Error(string errorId)
    {
        var message = await _interactionService.GetErrorContextAsync(errorId);

        if (!_environment.IsDevelopment())
        {
            message.ErrorDescription = null;
        }
        return Ok(message);
    }
}