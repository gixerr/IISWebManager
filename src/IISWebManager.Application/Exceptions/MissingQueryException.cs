namespace IISWebManager.Application.Exceptions
{
    public class MissingQueryException : ApplicationException
    {
        public override string Code => "missing_query";
        
        public MissingQueryException(string message) : base(message)
        {
        }

    }
}