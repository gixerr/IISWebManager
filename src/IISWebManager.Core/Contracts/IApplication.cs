namespace IISWebManager.Core.Contracts
{
    public interface IApplication
    {
        string Name { get; }
        IApplicationPool ApplicationPool { get; }
    }
}