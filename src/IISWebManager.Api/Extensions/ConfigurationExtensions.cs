using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;

namespace IISWebManager.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TSettings BindSettings<TSettings>(this IConfiguration configuration, string sectionName)
            where TSettings : new()
        {
            var settings = new TSettings();
            configuration.GetSection(sectionName).Bind(settings);

            return settings;
        }
    }
}