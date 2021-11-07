using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Paredev.Identity.Application.Endpoints.AuthenticationEndpoints;

public class Login : BaseAsyncEndpoint
    .WithRequest<LoginRequest>
    .WithoutResponse
{
    private readonly IIdentityServerInteractionService _interactionService;
    public Login(IIdentityServerInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    [HttpPost("/login")]
    public override async Task<ActionResult> HandleAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
    {
        var context = await _interactionService.GetAuthorizationContextAsync(request.RedirectUrl);

        return Unauthorized();
    }
}