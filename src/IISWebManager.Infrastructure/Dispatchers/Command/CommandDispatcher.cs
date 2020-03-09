using Autofac;
using IISWebManager.Application.Commands;
using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Handlers;
using IISWebManager.Infrastructure.Handlers.Commands;

namespace IISWebManager.Infrastructure.Dispatchers.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        
        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = _componentContext.Resolve<ICommandHandler<T>>();

            if (handler is null)
            {
                throw new MissingCommandHandlerException($"'{typeof(ICommandHandler<T>).Name}' is missing.");
            }
            
            handler.Handle(command);
        }
    }
}