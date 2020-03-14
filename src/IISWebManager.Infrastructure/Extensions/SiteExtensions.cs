using IISWebManager.Application.Exceptions;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Extensions
{
    public static class SiteExtensions
    {
        public static void ThrowIfNull(this Site site, string siteName)
        {
            if(site is null) throw new SiteNotExistsException(siteName);
        }
    }
}