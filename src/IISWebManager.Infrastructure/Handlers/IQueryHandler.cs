using IISWebManager.Application.Queries;

namespace IISWebManager.Infrastructure.Handlers
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}