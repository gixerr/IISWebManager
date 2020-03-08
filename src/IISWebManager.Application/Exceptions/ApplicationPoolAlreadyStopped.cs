namespace IISWebManager.Application.Exceptions
{
    public class ApplicationPoolAlreadyStopped : ApplicationException
    {
        public override string Code => "application_pool_already_stopped";
        
        public ApplicationPoolAlreadyStopped(string name) : base($"Application pool '{name}' is already stopped.")
        {
        }

    }
}