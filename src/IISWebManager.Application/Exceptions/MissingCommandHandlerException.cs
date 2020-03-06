namespace IISWebManager.Application.Exceptions
{
    public class MissingCommandHandlerException : ApplicationException
    {
        public override string Code => "missing_command_handler";
        
        public MissingCommandHandlerException(string message) : base(message)
        {
        }
    }
}