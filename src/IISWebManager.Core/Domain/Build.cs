using System;
using System.Collections.Generic;
using IISWebManager.Core.Contracts;
using IISWebManager.Core.Enums;
using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class Build : Model
    {
        private ISet<IApplication> _applications = new HashSet<IApplication>();

        public string Name { get; private set; }
        public BuildStatus Status { get; private set; }

        public IEnumerable<IApplication> Applications
        {
            get => _applications;
            private set => _applications = new HashSet<IApplication>(value);
        }

        public Build(string name, string status, IEnumerable<IApplication> applications)
        {
            SetNameOrThrow(name);
            SetStatusOrThrow(status);
            SetApplicationsOrThrow(applications);
        }

        private void SetNameOrThrow(string value) 
            => Name = ValueIsEmpty(value) ? throw new MissingBuildNameException() : value;

        private void SetStatusOrThrow(string value)
            => Status = Enum.TryParse(value, out BuildStatus status) ? status : throw new InvalidStatusException(value);

        private void SetApplicationsOrThrow(IEnumerable<IApplication> value)
        {
            if (ValueIsEmpty(value)) throw new MissingBuildApplicationsException();
            
            if (AnyCollectionValueIsEmpty(value)) throw new InvalidBuildApplicationException();
            
            Applications = value;
        }
    }
}