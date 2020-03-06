﻿using IISWebManager.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace IISWebManager.Api.IoC.Providers
{
    public class ServicesProvider
    {
        private IServiceCollection Services { get; set; }
        
        public ServicesProvider()
        {
        }

        public ServicesProvider Populate(IServiceCollection services)
        {
            Services = services ?? throw new MissingServicesCollectionException();
            Services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.Formatting = Formatting.Indented);

            return this;
        }

        public ServicesProvider LoadConfiguration(IConfiguration configuration)
        {
            return this;
        }
    }
}