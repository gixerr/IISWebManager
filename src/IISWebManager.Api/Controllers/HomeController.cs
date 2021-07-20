using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    [Route("home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
            => Ok("IIS Web Manager API");
    }
}