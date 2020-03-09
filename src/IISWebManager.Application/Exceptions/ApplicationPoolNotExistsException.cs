namespace IISWebManager.Application.Exceptions
{
    public class ApplicationPoolNotExistsException : ApplicationException
    {
        public override string Code => "application_pool_not_exist";

        public ApplicationPoolNotExistsException(string name) : base(
            $"Application pool with name '{name}' doesn't exists.")
        {
        }
    }
}