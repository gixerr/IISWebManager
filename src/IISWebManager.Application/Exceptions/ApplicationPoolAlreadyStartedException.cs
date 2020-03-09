namespace IISWebManager.Application.Exceptions
{
    public class ApplicationPoolAlreadyStartedException : ApplicationException
    {
        public override string Code => "application_pool_already_started";
        
        public ApplicationPoolAlreadyStartedException(string name) : base($"Application pool '{name}' is already started.")
        {
        }

    }
}