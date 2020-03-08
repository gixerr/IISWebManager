namespace IISWebManager.Application.Commands.ApplicationPools
{
    public class StopApplicationPool : ICommand
    {
        public StopApplicationPool(string applicationPoolName)
        {
            Name = applicationPoolName;
        }
        public string Name { get; }
    }
}