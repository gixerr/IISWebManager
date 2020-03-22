using IISWebManager.Core.Contracts;
using IISWebManager.Core.Domain;
using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.ValueObjects
{
    public class BuildApplication : Model, IApplication
    {
        public string Name { get; private set; }
        public IApplicationPool ApplicationPool { get; private set; }

        public BuildApplication(string name, IApplicationPool applicationPool)
        {
            SetName(name);
            SetApplicationPool(applicationPool);
        }

        private void SetName(string value)
            => Name = ValueIsEmpty(value) ? throw new MissingApplicationNameException() : value;

        private void SetApplicationPool(IApplicationPool applicationPool)
            => ApplicationPool = ValueIsEmpty(applicationPool)
                ? throw new MissingApplicationPoolException()
                : applicationPool;
    }
}