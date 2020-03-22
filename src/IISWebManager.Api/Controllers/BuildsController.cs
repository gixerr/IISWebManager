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
        public ActionResult Get([FromRoute] GetSiteBuilds query)
        {
            var buildsDto = QueryDispatcher.Dispatch(query);

            return Ok(buildsDto);
        }
    }
}