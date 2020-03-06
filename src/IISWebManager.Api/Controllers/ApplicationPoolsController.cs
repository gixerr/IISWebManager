using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Dispatchers.Command;
using IISWebManager.Infrastructure.Dispatchers.Query;
using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    public class ApplicationPoolsController : BaseController
    {
        public ApplicationPoolsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {
        }
        
        [HttpGet]
        public ActionResult Get([FromQuery] BrowseApplicationPools query)
        {
            var applicationPools = QueryDispatcher.Dispatch(query);

            return Ok(applicationPools);
        }
    }
}