namespace IISWebManager.Application.Exceptions
{
    public class SiteNotExistsException : ApplicationException
    {
        public override string Code => "site_not_exists";
        
        public SiteNotExistsException(string message) : base(message)
        {
        }
    }
}