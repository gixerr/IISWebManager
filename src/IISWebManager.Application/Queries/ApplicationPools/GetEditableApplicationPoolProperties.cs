﻿using IISWebManager.Application.DTO.ApplicationPools;

namespace IISWebManager.Application.Queries.ApplicationPools
{
    public class GetEditableApplicationPoolProperties : IQuery<ApplicationPoolEditablePropertiesDto>
    {
        public GetEditableApplicationPoolProperties(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}