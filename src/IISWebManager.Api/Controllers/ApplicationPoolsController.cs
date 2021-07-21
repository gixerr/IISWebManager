using System.ComponentModel.DataAnnotations;
using IISWebManager.Application.Commands.ApplicationPools;
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
        public ActionResult Browse()
        {
            var applicationPoolsDto = QueryDispatcher.Dispatch(new BrowseApplicationPools());

            return Ok(applicationPoolsDto);
        }

        [HttpGet("contains")]
        public ActionResult GetApplicationPoolsBySubstring([FromQuery][Required] string substring)
        {
            var applicationPoolsDto = QueryDispatcher.Dispatch(new GetApplicationPoolsContainedSubstring(substring));

            return Ok(applicationPoolsDto);
        }

        [HttpGet("{name}")]
        public ActionResult GetApplicationPoolByName(string name)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(new GetApplicationPool(name));

            return Ok(applicationPoolDto);
        }

        [HttpGet("{applicationPoolName}/editableProperties")]
        public ActionResult Edit(string applicationPoolName)
        {
            var applicationPoolDto =
                QueryDispatcher.Dispatch(new GetEditableApplicationPoolProperties(applicationPoolName));

            return Ok(applicationPoolDto);
        }

        [HttpPut("{applicationPoolName}/stop")]
        public ActionResult Stop(string applicationPoolName)
        {
            CommandDispatcher.Dispatch(new StopApplicationPool(applicationPoolName));
            
            return NoContent();
        }
        
        [HttpPut("{applicationPoolName}/start")]
        public ActionResult Start(string applicationPoolName)
        {
            CommandDispatcher.Dispatch(new StartApplicationPool(applicationPoolName));
            
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(AddApplicationPool command)
        {
            CommandDispatcher.Dispatch(command);
            
            return Created($"applicationPools/{command.Name}", null);
        }

        [HttpPut]
        public ActionResult Update(UpdateApplicationPool command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }

        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            CommandDispatcher.Dispatch(new DeleteApplicationPool(name));

            return NoContent();
        }
    }
}