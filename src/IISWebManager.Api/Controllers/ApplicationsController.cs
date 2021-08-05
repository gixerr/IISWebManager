using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IISWebManager.Application.Commands.Applications;
using IISWebManager.Application.DTO.Applications;
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

        /// <summary>
        /// Browse all applications
        /// </summary>
        /// <returns>akjhflkajshdlkasjhdlkasjhd</returns>
        /// <response code="200">Returns all applications from IIS server</response>
        [HttpGet("applications")]
        public ActionResult<IEnumerable<ApplicationGetDto>> Browse()
        {
            var applicationsDto = QueryDispatcher.Dispatch(new BrowseApplications());

            return Ok(applicationsDto);
        }

        /// <summary>
        /// Gets all applications from selected site
        /// </summary>
        /// <param name="siteName"></param>
        ///<response code="200">Returns all applications from selected Site</response>
        [HttpGet("{siteName}/applications")]
        public ActionResult<IEnumerable<ApplicationGetDto>> GetApplications(string siteName)
        {
            var applicationsDto = QueryDispatcher.Dispatch(new GetSiteApplications(siteName));

            return Ok(applicationsDto);
        }

        /// <summary>
        /// Gets all applications by substring contained in name from IIS
        /// </summary>
        /// <param name="subString">Desired substring</param>
        ///<response code="200">Returns all application which contains substring from IIS</response>
        [HttpGet("applications/contains")]
        public ActionResult<IEnumerable<ApplicationGetDto>> GetApplicationBySubstring(
            [FromQuery] [Required] string subString)
        {
            var applicationsDto = QueryDispatcher
                .Dispatch(new GetApplicationsContainedSubstring(null, subString));

            return Ok(applicationsDto);
        }

        /// <summary>
        /// Gets all applications by substring contained in name from IIS filtered by site name
        /// </summary>
        /// <param name="siteName">Selected site</param>
        /// <param name="subString">Desired substring</param>
        /// <response code="200">Returns all application which contains substring</response>
        [HttpGet("{siteName}/applications/contains")]
        public ActionResult<IEnumerable<ApplicationGetDto>> GetApplicationBySubstringFilteredBySiteName(string siteName,
            [FromQuery] [Required] string subString)
        {
            var applicationsDto = QueryDispatcher
                .Dispatch(new GetApplicationsContainedSubstring(siteName, subString));

            return Ok(applicationsDto);
        }
        
        /// <summary>
        /// Gets an application by name from IIS filtered by site name
        /// </summary>
        /// <param name="siteName">Selected site</param>
        /// <param name="applicationName">Name of desired application</param>
        /// <response code="200">Returns requested application</response>
        [HttpGet("{siteName}/applications/{applicationName}")]
        public ActionResult<ApplicationGetDto> GetApplicationByName(string siteName, string applicationName)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(new GetApplication(siteName, applicationName));

            return Ok(applicationPoolDto);
        }
        
        /// <summary>
        /// Gets application pool editable properties.
        /// </summary>
        /// <param name="siteName">Selected site</param>
        /// <param name="applicationName">Name of desired application</param>
        /// <response code="200">Returns editable properties of requested application</response>
        [HttpGet("{siteName}/applications/{applicationName}/editableProperties")]
        public ActionResult GetApplicationEditableProperties(string siteName, string applicationName)
        {
            var applicationDto =
                QueryDispatcher.Dispatch(new GetEditableApplicationProperties(siteName, applicationName));

            return Ok(applicationDto);
        }
        
        /// <summary>
        /// Creates new application
        /// </summary>
        /// <response code="201">Created</response>
        [HttpPost("applications")]
        public ActionResult Add(AddApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return Created($"applications/{command.ApplicationName}", null);
        }
        
        /// <summary>
        /// Updates application
        /// </summary>
        /// <response code="204">No Content</response>
        [HttpPut("applications")]
        public ActionResult Update(UpdateApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }
        
        /// <summary>
        /// Deletes application
        /// </summary>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad request</response>
        [HttpDelete("applications")]
        public ActionResult Delete(DeleteApplication command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }
    }
}