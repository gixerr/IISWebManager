using IISWebManager.Application.Queries.Builds;
using IISWebManager.Infrastructure.Dispatchers.Command;
using IISWebManager.Infrastructure.Dispatchers.Query;
using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    public class BuildsController : BaseController
    {
        public BuildsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) 
            : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("{siteName}")]
        public ActionResult Get(string siteName)
        {
            var buildsDto = QueryDispatcher.Dispatch(new GetSiteBuilds(siteName));

            return Ok(buildsDto);
        }
    }
}