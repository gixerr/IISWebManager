namespace IISWebManager.Core.Exceptions
{
    public class InvalidBuildApplicationException : DomainException
    {
        public override string Code => "invalid_build_application";
        
        public InvalidBuildApplicationException() : base("One of build applications is invalid.")
        {
        }
    }
}