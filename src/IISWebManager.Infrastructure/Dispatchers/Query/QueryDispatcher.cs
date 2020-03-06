using Autofac;
using IISWebManager.Application.Queries;
using IISWebManager.Infrastructure.Handlers.Query;

namespace IISWebManager.Infrastructure.Dispatchers.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _componentContext.Resolve(handlerType);

            return handler.Handle((dynamic) query);
        }
    }
}