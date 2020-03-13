namespace IISWebManager.Application.Exceptions
{
    public class MissingCommandException : ApplicationException
    {
        public override string Code => "missing_command";
        
        public MissingCommandException(string message) : base(message)
        {
        }
    }
}