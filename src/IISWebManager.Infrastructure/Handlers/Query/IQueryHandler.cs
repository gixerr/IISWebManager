using IISWebManager.Application.Queries;

namespace IISWebManager.Infrastructure.Handlers.Query
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}