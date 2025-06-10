using System.Security.Claims;
using Forum.Presentation.Web.Common.Api;
using Forum.Presentation.Web.Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.Web.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly IApiHttpClient _apiHttpClient;

    public AuthController(IApiHttpClient apiHttpClient)
    {
        _apiHttpClient = apiHttpClient;
    }

    [HttpGet("login")]
    public IActionResult LoginUser()
    {
        return View("Item", new LoginModel(null, null, null, null));
    }

    [HttpPost("login")]
    public async Task<IActionResult> AuthenticateUser([FromBody] LoginModel data, CancellationToken cancellationToken)
    {
        LoginModel result = await _apiHttpClient.PostAsync<LoginModel, LoginModel>("auth/login", data, cancellationToken);

        Response.Cookies.Delete("Token");
        Response.Cookies.Append("Token", result.Token!, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddMonths(1),
            Path = "/",
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.Strict
        });
        // tell asp.net we are logged in
        List<Claim> claims =
        [
            new Claim(ClaimTypes.Name, result.Username!),
            new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()!),
            new Claim("Token", result.Token!),
        ];
        ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)).ConfigureAwait(false);
        return Json(new { success = true, data });
    }

    [HttpGet("logout")]
    public async Task<IActionResult> LogoutUser(CancellationToken cancellationToken)
    {
        if (User?.Identity?.IsAuthenticated == false)

            return Redirect("/");

        Response.Cookies.Delete("Token");

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
        return Redirect("/auth/login");
    }
}
