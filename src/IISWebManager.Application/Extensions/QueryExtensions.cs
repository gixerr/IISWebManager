using IISWebManager.Application.Exceptions;
using IISWebManager.Application.Queries;

namespace IISWebManager.Application.Extensions
{
    public static class QueryExtensions
    {
        public static void ThrowIfNull<TResult>(this IQuery<TResult> query, string handlerName)
        {
            if (query is null) throw new MissingQueryException($"Handler '{handlerName}' received null query.");
        }
    }
}