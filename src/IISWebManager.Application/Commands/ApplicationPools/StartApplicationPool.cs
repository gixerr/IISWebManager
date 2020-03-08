namespace IISWebManager.Application.Commands.ApplicationPools
{
    public class StartApplicationPool : ICommand
    {
        public StartApplicationPool(string applicationPoolName)
        {
            Name = applicationPoolName;
        }
        public string Name { get; }
    }
}