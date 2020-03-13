namespace IISWebManager.Application.Exceptions
{
    public class InvalidIdentityTypeException : ApplicationException
    {
        public override string Code => "invalid_identity_type";
        public InvalidIdentityTypeException(string identityType) 
            : base($"Identity type '{identityType}' is invalid.")
        {
        }
    }
}