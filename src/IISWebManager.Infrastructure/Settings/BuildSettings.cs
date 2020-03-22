using System.Collections.Generic;

namespace IISWebManager.Infrastructure.Settings
{
    public class BuildSettings
    {
        public string NamingConventionSeparator { get; set; }
        public IEnumerable<string> UndesiredPaths { get; set; }
    }
}