using IISWebManager.Application.Commands.Applications;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Dispatchers.Command;
using IISWebManager.Infrastructure.Dispatchers.Query;
using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    [Route("sites")]
    public class ApplicationsController : BaseController
    {
        public ApplicationsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) 
            : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("applications")]
        public ActionResult Get([FromQuery] BrowseApplications query)
        {
            var applicationsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationsDto);
        }

        [HttpGet("{siteName}/applications")]
        public ActionResult Get([FromRoute] GetSiteApplications query)
        {
            var applicationsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationsDto);
        }

        [HttpGet("applications/contains")]
        [HttpGet("{siteName}/applications/contains")]
        public ActionResult Get(string siteName, [FromQuery] string subString)
        {
            var query = new GetApplicationsContainedSubstring(siteName, subString);
            var applicationsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationsDto);
        }
        
        [HttpGet("{siteName}/applications/{applicationName}")]
        public ActionResult Get([FromRoute] GetApplication query)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationPoolDto);
        }

        [HttpGet("{siteName}/applications/{applicationName}/editableProperties")]
        public ActionResult Get([FromRoute] GetEditableApplicationProperties query)
        {
            var applicationDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationDto);
        }
        
        [HttpPost("applications")]
        public ActionResult Add(AddApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return Created($"applications/{command.ApplicationName}", null);
        }

        [HttpPut("applications")]
        public ActionResult Update(UpdateApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }

        [HttpDelete("applications")]
        public ActionResult Delete(DeleteApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }
    }
}