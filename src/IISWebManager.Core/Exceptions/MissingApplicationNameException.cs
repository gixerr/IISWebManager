namespace IISWebManager.Core.Exceptions
{
    public class MissingApplicationNameException : DomainException
    {
        public override string Code => "missing_application_name";
        
        public MissingApplicationNameException() : base("Application name is missing.")
        {
        }

    }
}