using System;
using System.IO;
using System.Reflection;
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
                    Description = "<b>Through this API you can manage IIS on server.</b>",
                    Version = "1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Paweł Wardyń",
                        Email = "pwardyn213@gmail.com"
                        
                    }
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
                //TODO: Refactor
                setupAction.IncludeXmlComments("C:/dev/codeRepo/projects/core/IISWebManager/src/IISWebManager.Application/IISWebManager.Application.xml");
            });
            Services = services;

            return this;
        }
    }
}