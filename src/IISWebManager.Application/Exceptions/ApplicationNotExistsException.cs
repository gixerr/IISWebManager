namespace IISWebManager.Application.Exceptions
{
    public class ApplicationNotExistsException : ApplicationException
    {
        public override string Code => "application_not_exists";
        
        public ApplicationNotExistsException(string name) 
            : base($"Application with name '{name}' doesn't exists.")
        {
        }
    }
}