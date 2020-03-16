using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class ApiApplication : Model
    {
        public string Name { get; private set; }
        public string VirtualPath { get; private set; }
        public string PhysicalPath { get; private set; }
        public ApplicationPool ApplicationPool { get; private set; }

        public ApiApplication(string name, string virtualPath, string physicalPath, ApplicationPool applicationPool)
        {
            SetNameOrThrow(name);
            SetVirtualPathOrThrow(virtualPath);
            SetPhysicalPathOrThrow(physicalPath);
            SetApplicationPoolOrThrow(applicationPool);
        }

        private void SetNameOrThrow(string value) 
            => Name = ValueIsEmpty(value) ? throw new MissingApplicationNameException() : value;

        private void SetVirtualPathOrThrow(string value) 
            => VirtualPath = ValueIsEmpty(value) ? throw new MissingApplicationVirtualPathException() : value;

        private void SetPhysicalPathOrThrow(string value)
            => PhysicalPath = ValueIsEmpty(value) ? throw new MissingApplicationPhysicalPathException() : value;

        private void SetApplicationPoolOrThrow(ApplicationPool value)
            => ApplicationPool = ValueIsEmpty(value) ? throw new MissingApplicationPoolException() : value;
    }
}