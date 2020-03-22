using Autofac;
using IISWebManager.Api.Extensions;
using IISWebManager.Api.IoC.Providers;
using IISWebManager.Infrastructure.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Web.Administration;

namespace IISWebManager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var servicesProvider = new ServicesProvider();
            servicesProvider.Populate(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<ServerManager>().InstancePerLifetimeScope();
            builder.RegisterInstance(AutoMapperConfiguration.GetMapper());
            builder.RegisterModule(new ModulesProvider());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime hostApplicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandler();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.DisposeAutofacContainer(hostApplicationLifetime);
        }
    }
}