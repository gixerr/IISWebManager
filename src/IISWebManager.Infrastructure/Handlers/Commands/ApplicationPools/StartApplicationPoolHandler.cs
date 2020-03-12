﻿using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class StartApplicationPoolHandler : ICommandHandler<StartApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public StartApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }
        public void Handle(StartApplicationPool command)
        {
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfNull(command.Name);
            applicationPool.ThrowIfStarted();
            
            _applicationPoolFacade.StartApplicationPool(applicationPool);
        }
    }
}