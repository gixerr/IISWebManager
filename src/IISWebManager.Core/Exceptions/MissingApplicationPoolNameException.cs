namespace IISWebManager.Core.Exceptions
{
    public class MissingApplicationPoolNameException : DomainException
    {
        public override string Code => "missing_application_pool_name";
        
        public MissingApplicationPoolNameException() : base("Application pool name is missing.")
        {
        }
    }
}