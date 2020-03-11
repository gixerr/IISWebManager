﻿using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Facades;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class StopApplicationPoolHandler : ICommandHandler<StopApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public StopApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }

        public void Handle(StopApplicationPool command)
        {
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            if (applicationPool is null)
            {
                throw new ApplicationPoolNotExistsException(command.Name);
            }

            if (applicationPool.State == ObjectState.Stopped)
            {
                throw new ApplicationPoolAlreadyStoppedException(command.Name);
            }

            _applicationPoolFacade.StopApplicationPool(applicationPool);
        }
    }
}