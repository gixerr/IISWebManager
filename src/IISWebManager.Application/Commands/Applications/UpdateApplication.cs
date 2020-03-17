namespace IISWebManager.Application.Commands.Applications
{
    public class UpdateApplication : ICommand
    {
        public string SiteName { get; set; }
        public string ApplicationName { get; set; }
        public string NewApplicationName { get; set; }
        public string ApplicationPoolName { get; set; }
        public string PhysicalPath { get; set; }
    }
}