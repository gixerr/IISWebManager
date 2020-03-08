namespace IISWebManager.Application.Exceptions
{
    public class ApplicationPoolAlreadyStarted : ApplicationException
    {
        public override string Code => "application_pool_already_started";
        
        public ApplicationPoolAlreadyStarted(string name) : base($"Application pool '{name}' is already started.")
        {
        }

    }
}