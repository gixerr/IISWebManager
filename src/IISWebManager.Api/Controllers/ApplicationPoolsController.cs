using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.DTO.ApplicationPools;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Dispatchers.Command;
using IISWebManager.Infrastructure.Dispatchers.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IISWebManager.Api.Controllers
{
    public class ApplicationPoolsController : BaseController
    {
        public ApplicationPoolsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {
        }
        
        /// <summary>
        /// Browse all application pools.
        /// </summary>
        /// <response code="200">Returns all application pools</response>
        [HttpGet]
        public ActionResult<IEnumerable<ApplicationPoolGetDto>> Browse()
        {
            var applicationPoolsDto = QueryDispatcher.Dispatch(new BrowseApplicationPools());

            return Ok(applicationPoolsDto);
        }
        
        /// <summary>
        /// Gets an application pool by substring contained in name.
        /// </summary>
        /// <param name="substring">Desired substring</param>
        /// <response code="200">Returns all application pools which contains substring</response>
        [HttpGet("contains")]
        public ActionResult<IEnumerable<ApplicationPoolGetDto>> GetApplicationPoolsBySubstring([FromQuery][Required] string substring)
        {
            var applicationPoolsDto = QueryDispatcher.Dispatch(new GetApplicationPoolsContainedSubstring(substring));

            return Ok(applicationPoolsDto);
        }
        
        /// <summary>
        /// Gets an application pool by its name.
        /// </summary>
        /// <param name="name">Name of desired application pool</param>
        /// <response code="200">Returns requested application pool</response>
        [HttpGet("{name}")]
        public ActionResult<ApplicationPoolGetDto> GetApplicationPoolByName(string name)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(new GetApplicationPool(name));

            return Ok(applicationPoolDto);
        }
        
        /// <summary>
        /// Gets application pool editable properties.
        /// </summary>
        /// <param name="name">Name of the desired application pool</param>
        /// <response code="200">Returns editable properties of requested application</response>
        [HttpGet("{name}/editableProperties")]
        public ActionResult<ApplicationPoolEditablePropertiesDto> Edit(string name)
        {
            var applicationPoolDto =
                QueryDispatcher.Dispatch(new GetEditableApplicationPoolProperties(name));

            return Ok(applicationPoolDto);
        }
        
        /// <summary>
        /// Stops application pool
        /// </summary>
        /// <param name="name">Name of the desired application pool to stop</param>
        /// <response code="204">No Content</response>
        [HttpPut("{name}/stop")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Stop(string name)
        {
            CommandDispatcher.Dispatch(new StopApplicationPool(name));
            
            return NoContent();
        }
        
        /// <summary>
        /// Starts application pool
        /// </summary>
        /// <param name="name">Name of the desired application pool to start</param>
        /// <response code="204">No Content</response>
        [HttpPut("{name}/start")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Start(string name)
        {
            CommandDispatcher.Dispatch(new StartApplicationPool(name));
            
            return NoContent();
        }

        /// <summary>
        /// Creates new application pool
        /// </summary>
        /// <response code="201">Created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Add(AddApplicationPool command)
        {
            CommandDispatcher.Dispatch(command);
            
            return Created($"applicationPools/{command.Name}", null);
        }
        
        /// <summary>
        /// Updates application pool
        /// </summary>
        /// <response code="204">No Content</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(UpdateApplicationPool command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }
        
        /// <summary>
        /// Deletes application pool
        /// </summary>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad request</response>
        [HttpDelete("{name}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(string name)
        {
            CommandDispatcher.Dispatch(new DeleteApplicationPool(name));

            return NoContent();
        }
    }
}