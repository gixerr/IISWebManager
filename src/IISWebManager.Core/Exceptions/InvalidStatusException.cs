namespace IISWebManager.Core.Exceptions
{
    public class InvalidStatusException : DomainException
    {
        public override string Code => "invalid_status";
        
        public InvalidStatusException(string status) : base($"Provided status '{status}' is invalid.")
        {
        }
    }
}