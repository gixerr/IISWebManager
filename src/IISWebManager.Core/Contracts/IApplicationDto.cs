namespace IISWebManager.Core.Contracts
{
    public interface IApplicationDto
    {
        string Name { get; }
        IApplicationPoolDto ApiApplicationPoolDto { get; }
    }
}