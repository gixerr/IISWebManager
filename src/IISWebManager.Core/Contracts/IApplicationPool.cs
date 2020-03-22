namespace IISWebManager.Core.Contracts
{
    public interface IApplicationPool
    {
        string Name { get; }
        string Status { get; }
    }
}