using Forum.Presentation.Web.Common.Api;
using Forum.Presentation.Web.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.Web.Controllers;

[Route("movies")]
public class MoviesController : Controller
{
    private readonly IApiHttpClient _apiHttpClient;

    public MoviesController(IApiHttpClient apiHttpClient)
    {
        _apiHttpClient = apiHttpClient;
    }
    [HttpGet("list")]
    public async Task<IActionResult> Index()
    {
        MovieModel[] result = await _apiHttpClient.GetAsync<MovieModel[]>("movies");
        return View(result);
    }

    [HttpGet("item")]
    public IActionResult AddMovie()
    {
        return View("Item", new MovieModel(null, null, null, null, null, null, null));
    }

    [HttpGet("item/{id}")]
    public async Task<IActionResult> DisplayMovie(Guid id, CancellationToken cancellationToken)
    {
        MovieModel result = await _apiHttpClient.GetAsync<MovieModel>("movies/" + id, cancellationToken);
        ViewData["whatever"] = 7;
        //ViewBag.whatever2 = "ceva";
        return View("Item", result);
    }

    [HttpPost("item/{id}")]
    public async Task<IActionResult> UpdateMovie([FromBody]MovieModel data, Guid id, CancellationToken cancellationToken)
    {
        try
        {
            MovieModel result = await _apiHttpClient.PutAsync<MovieModel, MovieModel>("movies/" + id, data, cancellationToken);
            //ViewData["whatever"] = 7;
            ////ViewBag.whatever2 = "ceva";
            //return View("Item", result);
            //return View("/Views/Movies/Item.cshtml", new MovieModel(Guid.Empty, string.Empty, null, null, null, null, null));
            return Json(new { success = true, data });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, data = ex.Message });

        }

    }

    [HttpPost("item")]
    public async Task<IActionResult> CreateMovie([FromBody] MovieModel data, CancellationToken cancellationToken)
    {
        MovieModel result = await _apiHttpClient.PostAsync<MovieModel, MovieModel>("movies/", data, cancellationToken);
        //ViewData["whatever"] = 7;
        ////ViewBag.whatever2 = "ceva";
        //return View("Item", result);
        //return View("/Views/Movies/Item.cshtml", new MovieModel(Guid.Empty, string.Empty, null, null, null, null, null));
        return Json(new { success = true, data });
    }

    [HttpDelete("item/{id}")]
    public async Task<IActionResult> DeleteMovie(Guid id, CancellationToken cancellationToken)
    {
        await _apiHttpClient.DeleteAsync("movies/" + id, cancellationToken);
        //ViewData["whatever"] = 7;
        ////ViewBag.whatever2 = "ceva";
        //return View("Item", result);
        //return View("/Views/Movies/Item.cshtml", new MovieModel(Guid.Empty, string.Empty, null, null, null, null, null));
        MovieModel[] result = await _apiHttpClient.GetAsync<MovieModel[]>("movies");
        return View("Index", result);
    }
}
