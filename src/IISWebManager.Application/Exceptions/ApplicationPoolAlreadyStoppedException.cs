namespace IISWebManager.Application.Exceptions
{
    public class ApplicationPoolAlreadyStoppedException : ApplicationException
    {
        public override string Code => "application_pool_already_stopped";
        
        public ApplicationPoolAlreadyStoppedException(string name) : base($"Application pool '{name}' is already stopped.")
        {
        }

    }
}