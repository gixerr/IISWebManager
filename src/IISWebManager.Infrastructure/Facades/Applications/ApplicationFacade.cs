using System;
using System.Collections.Generic;
using System.Linq;
using IISWebManager.Infrastructure.Extensions;
using Microsoft.Web.Administration;
 using App = Microsoft.Web.Administration.Application;
 
 namespace IISWebManager.Infrastructure.Facades.Applications
 {
     public class ApplicationFacade : IApplicationFacade
     {
         private readonly ServerManager _serverManager;

         public ApplicationFacade(ServerManager serverManager)
         {
             _serverManager = serverManager;
         }
         public IEnumerable<App> BrowseApplications() 
             => _serverManager.Sites.SelectMany(x => x.Applications);
 
         public ApplicationCollection GetSiteApplications(string siteName)
         {
             var site = _serverManager.Sites
                 .SingleOrDefault(x => x.Name.Equals(siteName, StringComparison.OrdinalIgnoreCase));
             site.ThrowIfNull(siteName);

             return site.Applications;
         }
     }
 }