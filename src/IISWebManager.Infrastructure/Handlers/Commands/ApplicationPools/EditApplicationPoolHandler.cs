﻿using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Extensions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;
using IISWebManager.Infrastructure.Utils;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class EditApplicationPoolHandler : ICommandHandler<EditApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public EditApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }

        public void Handle(EditApplicationPool command)
        {
            command.ThrowIfNull(GetType().Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfNull(command.Name);
            applicationPool.Name = command.NewName;
            applicationPool.ManagedPipelineMode =
                ApplicationPoolUtils.ParseToEnumOrThrow<ManagedPipelineMode>(command.ManagedPipelineMode);
            applicationPool.ManagedRuntimeVersion = command.ManagedRuntimeVersion;
            applicationPool.ProcessModel.IdentityType =
                ApplicationPoolUtils.ParseToEnumOrThrow<ProcessModelIdentityType>(command.Identity);
            _applicationPoolFacade.EditApplicationPool();
        }
    }
}