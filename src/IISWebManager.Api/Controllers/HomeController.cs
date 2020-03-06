using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public ActionResult Get()
            => Ok("IIS Web Manager");
    }
}