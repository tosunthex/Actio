using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        // GET
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio API!");
    }
}