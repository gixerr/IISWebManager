﻿using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetApplication : IQuery<ApplicationGetDto>
    {
        public string Name { get; set; }
        public string SiteName { get; set; }
    }
}