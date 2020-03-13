using IISWebManager.Application.Commands;
using IISWebManager.Application.Exceptions;

namespace IISWebManager.Application.Extensions
{
    public static class CommandExtensions
    {
        public static void ThrowIfNull(this ICommand command, string callerName)
        {
            if (command is null) throw new MissingCommandException($"Handler '{callerName}' received null query.");
        }
    }
}