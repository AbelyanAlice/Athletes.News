using Athletes.News.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athletes.News.Api.Controllers
{
    [Route("api/athletes")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var service = new SomeService();
            return Ok("Hello World");
        }
    }
}
