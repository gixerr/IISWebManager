namespace IISWebManager.Core.Exceptions
{
    public class MissingBuildNameException : DomainException
    {
        public override string Code => "missing_build_name";
        
        public MissingBuildNameException() : base("Build name is missing.")
        {
        }

    }
}