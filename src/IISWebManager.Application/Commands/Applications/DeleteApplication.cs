namespace IISWebManager.Application.Commands.Applications
{
    public class DeleteApplication : ICommand
    {
        public string SiteName { get; set; }
        public string ApplicationName { get; set; }
    }
}