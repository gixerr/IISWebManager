namespace IISWebManager.Application.Commands.ApplicationPools
{
    public class DeleteApplicationPool : ICommand
    {
        public DeleteApplicationPool(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}