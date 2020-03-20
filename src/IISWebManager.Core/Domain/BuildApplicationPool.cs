using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class BuildApplicationPool : Model
    {
        public string Name { get; private set; }
        public string DotNetClrVersion { get; private set; }
        public string ManagedPipelineMode { get; private set; }
        public bool StartApplicationPoolImmediately { get; private set; }

        public BuildApplicationPool(string name, string dotNetClrVersion, string managedPipelineMode,
            bool startApplicationPoolImmediately = false)
        {
            SetNameOrThrow(name);
            SetDotNetClrVersionOrThrow(dotNetClrVersion);
            SetManagedPipelineModeOrThrow(managedPipelineMode);
            StartApplicationPoolImmediately = startApplicationPoolImmediately;
        }

        private void SetNameOrThrow(string value)
            => Name = ValueIsEmpty(value) ? throw new MissingApplicationPoolNameException() : value;

        private void SetDotNetClrVersionOrThrow(string value)
            => DotNetClrVersion =
                ValueIsEmpty(value) ? throw new MissingApplicationPoolDotNetClrVersionException() : value;

        private void SetManagedPipelineModeOrThrow(string value)
            => ManagedPipelineMode = ValueIsEmpty(value)
                ? throw new MissingApplicationPoolManagedPipelineModeException()
                : value;
    }
}