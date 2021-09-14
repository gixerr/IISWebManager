using System.Security.Cryptography;

namespace IISWebManager.Application.Commands.ApplicationPools
{
    public class RecycleApplicationPool : ICommand
    {
        public RecycleApplicationPool(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}