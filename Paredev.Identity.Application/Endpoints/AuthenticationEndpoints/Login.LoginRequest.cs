namespace Paredev.Identity.Application.Endpoints.AuthenticationEndpoints;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string RedirectUrl { get; set; }
}