using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Paredev.Identity.Application.Endpoints.AuthenticationEndpoints;

public class Error : BaseAsyncEndpoint
.WithRequest<ErrorRequest>
.WithoutResponse
{
    private readonly IIdentityServerInteractionService _interactionService;
    private readonly IWebHostEnvironment _environment;
    public Error(IIdentityServerInteractionService interactionService, IWebHostEnvironment environment)
    {
        _interactionService = interactionService;
        _environment = environment;
    }

    [HttpGet("error")]
    public override async Task<ActionResult> HandleAsync(ErrorRequest request, CancellationToken cancellationToken = default)
    {
        var error = await _interactionService.GetErrorContextAsync(request.ErrorId);
        if (_environment.IsDevelopment())
        {
            error.ErrorDescription = string.Empty;
        }
        
        return Ok(error);
    }
}

