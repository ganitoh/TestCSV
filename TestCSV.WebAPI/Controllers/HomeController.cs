using Microsoft.AspNetCore.Mvc;
using TestCSV.Application.Services.Abstraction;

namespace TestCSV.WebAPI.Controllers
{
    [Route("/home")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return Content("hello world!!!");
        }

        [HttpGet("home/read-email")]
        public async Task<IActionResult> ReadEmail()
        {
            await _homeService.CheckEmailAsync();
            return Ok();
        }
    }
}
