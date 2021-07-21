using IISWebManager.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
            if (services is null)
            {
                throw new MissingServicesCollectionException();
            }

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.Formatting = Formatting.Indented);

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("OpenApi", new OpenApiInfo()
                {
                    Title = "IIS Web Manager API",
                    Version = "1"
                });
            });

            Services = services;

            return this;
        }
    }
}