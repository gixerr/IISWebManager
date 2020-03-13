namespace IISWebManager.Application.Exceptions
{
    public class MissingServicesCollectionException : ApplicationException
    {
        public override string Code => "missing_service_collection";
        
        public MissingServicesCollectionException() : base("Services Collection is missing.")
        {
        }
    }
}