using IISWebManager.Application.Exceptions;

namespace IISWebManager.Infrastructure.Facades
{
    public class ApplicationPoolNotExistsException : ApplicationException
    {
        public override string Code => "application_pool_not_exist";

        public ApplicationPoolNotExistsException(string name) : base(
            $"Application pool with provided name '{name}' doesn't exists.")
        {
        }
    }
}