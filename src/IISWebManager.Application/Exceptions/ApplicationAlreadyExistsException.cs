namespace IISWebManager.Application.Exceptions
{
    public class ApplicationAlreadyExistsException : ApplicationException
    {
        public override string Code => "application_already_exists";
        
        public ApplicationAlreadyExistsException(string applicationName) 
            : base($"Application with name '{applicationName}' already exists.")
        {
        }
    }
}