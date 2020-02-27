using System;
using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class MissingApplicationPhysicalPathException : DomainException
    {
        public override string Code => "missing_application_physical_path";
        
        public MissingApplicationPhysicalPathException() : base("Application physical path is missing.")
        {
        }

    }
}