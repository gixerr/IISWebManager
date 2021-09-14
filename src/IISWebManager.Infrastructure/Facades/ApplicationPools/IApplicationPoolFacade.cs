﻿using System.Collections.Generic;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Facades.ApplicationPools
{
    public interface IApplicationPoolFacade
    {
        ApplicationPoolCollection BrowseApplicationPools();
        IEnumerable<ApplicationPool> GetApplicationPools(string subString);
        ApplicationPool GetApplicationPool(string name);
        void StartApplicationPool(ApplicationPool applicationPool);
        void StopApplicationPool(ApplicationPool applicationPool);
        void RecycleApplicationPool(ApplicationPool applicationPool);
        void AddApplicationPool(string name, ManagedPipelineMode managedPipelineMode, string managedRuntimeVersion,
            bool autoStart);
        void UpdateApplicationPool();
        void DeleteApplicationPool(ApplicationPool applicationPool);
    }
}