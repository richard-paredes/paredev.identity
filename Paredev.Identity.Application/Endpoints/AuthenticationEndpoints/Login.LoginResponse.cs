namespace Paredev.Identity.Application.Endpoints.AuthenticationEndpoints;

public class LoginResponse
{
    public string RedirectUrl { get; set; }
    public bool IsOk { get; set; }

    public static LoginResponse UnauthorizedLogin => new LoginResponse
    {
        RedirectUrl = string.Empty,
        IsOk = false
    };
}