using IISWebManager.Application.Commands;

namespace IISWebManager.Infrastructure.Handlers.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
}