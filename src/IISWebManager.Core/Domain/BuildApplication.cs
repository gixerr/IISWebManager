using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class BuildApplication : Model
    {
        public string Name { get; private set; }
        public string VirtualPath { get; private set; }
        public string PhysicalPath { get; private set; }
        public BuildApplicationPool BuildApplicationPool { get; private set; }

        public BuildApplication(string name, string virtualPath, string physicalPath, BuildApplicationPool buildApplicationPool)
        {
            SetNameOrThrow(name);
            SetVirtualPathOrThrow(virtualPath);
            SetPhysicalPathOrThrow(physicalPath);
            SetApplicationPoolOrThrow(buildApplicationPool);
        }

        private void SetNameOrThrow(string value) 
            => Name = ValueIsEmpty(value) ? throw new MissingApplicationNameException() : value;

        private void SetVirtualPathOrThrow(string value) 
            => VirtualPath = ValueIsEmpty(value) ? throw new MissingApplicationVirtualPathException() : value;

        private void SetPhysicalPathOrThrow(string value)
            => PhysicalPath = ValueIsEmpty(value) ? throw new MissingApplicationPhysicalPathException() : value;

        private void SetApplicationPoolOrThrow(BuildApplicationPool value)
            => BuildApplicationPool = ValueIsEmpty(value) ? throw new MissingApplicationPoolException() : value;
    }
}