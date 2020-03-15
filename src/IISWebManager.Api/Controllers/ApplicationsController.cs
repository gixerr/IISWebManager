using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Dispatchers.Command;
using IISWebManager.Infrastructure.Dispatchers.Query;
using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    public class ApplicationsController : BaseController
    {
        public ApplicationsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) 
            : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet]
        public ActionResult Get([FromQuery] BrowseApplications query)
        {
            var applicationsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationsDto);
        }

        [HttpGet("site/{name}")]
        public ActionResult Get([FromRoute] GetSiteApplications query)
        {
            var applicationsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationsDto);
        }
    }
}