using IISWebManager.Core.Contracts;
using IISWebManager.Core.Domain;
using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.ValueObjects
{
    public class BuildApplicationPool : Model, IApplicationPool
    {
        public string Name { get; private set; }
        public string Status { get; private set; }

        public BuildApplicationPool(string name, string status)
        {
            SetName(name);
            SetStatus(status);
        }
        
        private void SetName(string value)
            => Name = ValueIsEmpty(value) ? throw new MissingApplicationPoolNameException() : value;

        private void SetStatus(string value)
            => Status = ValueIsEmpty(value) ? throw new MissingApplicationPoolStatusException() : value;
    }
    
}