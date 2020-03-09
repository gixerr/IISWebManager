namespace IISWebManager.Application.Exceptions
{
    public class ApplicationPoolAlreadyExistsException : ApplicationException
    {
        public override string Code => "application_pool_already_exists";
        
        public ApplicationPoolAlreadyExistsException(string applicationPoolName) 
            : base($"Application pool with name '{applicationPoolName}' already exists.")
        {
        }
    }
}