using System.Collections.Generic;
using System.ComponentModel;
using IISWebManager.Core.Contracts;

namespace IISWebManager.Application.DTO.Builds
{
    public class BuildGetDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public IEnumerable<IApplication> Applications { get; set; }
    }
}