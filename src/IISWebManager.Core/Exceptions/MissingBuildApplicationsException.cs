namespace IISWebManager.Core.Exceptions
{
    public class MissingBuildApplicationsException : DomainException
    {
        public override string Code => "missing_build_applications";
        
        public MissingBuildApplicationsException() : base("Build applications are missing.")
        {
        }

    }
}