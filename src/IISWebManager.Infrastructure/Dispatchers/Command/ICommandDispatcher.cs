using IISWebManager.Application.Commands;

namespace IISWebManager.Infrastructure.Dispatchers.Command
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
    }
}