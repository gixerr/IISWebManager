using System;

namespace IISWebManager.Core.Exceptions
{
    public class MissingApplicationPoolDotNetClrVersionException : DomainException
    {
        public override string Code => "missing_dot_net_clr_version";
        
        public MissingApplicationPoolDotNetClrVersionException() : base(".NET CLR version is missing.")
        {
        }
    }
}