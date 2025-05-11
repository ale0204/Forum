using System.Diagnostics;
using Forum.Presentation.Web.Common.Api;
using Forum.Presentation.Web.Common.Models;
using Forum.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiHttpClient _apiHttpClient;

        public HomeController(ILogger<HomeController> logger, IApiHttpClient apiHttpClient)
        {
            _logger = logger;
            _apiHttpClient = apiHttpClient;
        }

        public IActionResult Index()
        {
            //MovieModel result = await _apiHttpClient.GetAsync<MovieModel>("movies/fd46309f-3d03-4619-ae72-f3914ba30366");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
