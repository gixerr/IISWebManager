namespace IISWebManager.Application.Exceptions
{
    public class MissingServicesCollectionException : ApplicationException
    {
        public override string Code { get; }
        
        public MissingServicesCollectionException() : base("Services Collection is missing.")
        {
        }
    }
}