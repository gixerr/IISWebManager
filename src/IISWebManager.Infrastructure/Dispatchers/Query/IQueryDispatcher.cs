using IISWebManager.Application.Queries;

namespace IISWebManager.Infrastructure.Dispatchers.Query
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TResult>(IQuery<TResult> query);
    }
}