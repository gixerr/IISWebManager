using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class MissingApplicationVirtualPathException : DomainException
    {
        public override string Code => "missing_application_virtual_path";
        
        public MissingApplicationVirtualPathException() : base("Application virtual path is missing.")
        {
        }

    }
}