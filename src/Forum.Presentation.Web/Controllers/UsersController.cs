using Forum.Presentation.Web.Common.Api;
using Forum.Presentation.Web.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.Web.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IApiHttpClient _apiHttpClient;

    public UsersController(IApiHttpClient apiHttpClient)
    {
        _apiHttpClient = apiHttpClient;
    }

    [HttpGet("item")]
    public IActionResult AddUser()
    {
        return View("Item", new UserModel(null, null, null, null));
    }

    [HttpPost("item")]
    public async Task<IActionResult> CreateUser([FromBody] UserModel data, CancellationToken cancellationToken)
    {
        UserModel result = await _apiHttpClient.PostAsync<UserModel, UserModel>("users/", data, cancellationToken);
        return Json(new { success = true, data });
    }
}
