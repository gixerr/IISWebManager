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
        public ActionResult Get([FromQuery] BrowseApplicationPools query)
        {
            var applicationPoolsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationPoolsDto);
        }

        [HttpGet("contains")]
        public ActionResult Get([FromQuery] GetApplicationPoolsContainedSubstring query)
        {
            var applicationPoolsDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationPoolsDto);
        }

        [HttpGet("{name}")]
        public ActionResult Get([FromRoute] GetApplicationPool query)
        {
            var applicationPoolDto = QueryDispatcher.Dispatch(query);

            return Ok(applicationPoolDto);
        }

        [HttpGet("{applicationPoolName}/edit")]
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

        [HttpDelete("{name}")]
        public ActionResult Delete([FromRoute] DeleteApplicationPool command)
        {
            CommandDispatcher.Dispatch(command);

            return NoContent();
        }
    }
}