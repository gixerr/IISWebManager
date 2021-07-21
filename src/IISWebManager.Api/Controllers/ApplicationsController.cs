using System.ComponentModel.DataAnnotations;
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
        public ActionResult Browse()
        {
            var applicationsDto = QueryDispatcher.Dispatch(new BrowseApplications());

            return Ok(applicationsDto);
        }

        [HttpGet("{siteName}/applications")]
        public ActionResult GetApplications(string siteName)
        {
            var applicationsDto = QueryDispatcher.Dispatch(new GetSiteApplications(siteName));

            return Ok(applicationsDto);
        }

        [HttpGet("applications/contains")]
        [HttpGet("{siteName}/applications/contains")]
        public ActionResult GetApplicationBySubstring(string siteName, [FromQuery][Required] string subString)
        {
            var applicationsDto = QueryDispatcher
                .Dispatch(new GetApplicationsContainedSubstring(siteName, subString));

            return Ok(applicationsDto);
        }

        [HttpGet("{siteName}/applications/{applicationName}")]
        public ActionResult GetApplicationByName(string siteName, string applicationName)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(new GetApplication(siteName, applicationName));

            return Ok(applicationPoolDto);
        }

        [HttpGet("{siteName}/applications/{applicationName}/editableProperties")]
        public ActionResult GetApplicationEditableProperties(string siteName, string applicationName)
        {
            var applicationDto = QueryDispatcher.Dispatch(new GetEditableApplicationProperties(siteName, applicationName));

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