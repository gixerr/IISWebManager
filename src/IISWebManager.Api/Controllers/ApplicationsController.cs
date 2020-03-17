using IISWebManager.Application.Commands.Applications;
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

        [HttpGet("contains")]
        public ActionResult Get([FromQuery] GetApplicationsContainedSubstring query)
        {
            var applicationsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationsDto);
        }
        
        [HttpGet("site/{siteName}/{name}")]
        public ActionResult Get([FromRoute] GetApplication query)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationPoolDto);
        }

        [HttpGet("{name}/site/{siteName}/editableProperties")]
        public ActionResult Get([FromRoute] GetEditableApplicationProperties query)
        {
            var applicationDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationDto);
        }
        
        [HttpPost]
        public ActionResult Add(AddApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return Created($"applications/{command.Name}", null);
        }
    }
}