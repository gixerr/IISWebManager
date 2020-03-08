using Autofac.Extensions.DependencyInjection;
using IISWebManager.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace IISWebManager.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void DisposeAutofacContainer(this IApplicationBuilder app,
            IHostApplicationLifetime hostApplicationLifetime)
            => hostApplicationLifetime.ApplicationStopped.Register(() 
                => app.ApplicationServices.GetAutofacRoot().Dispose());

        public static void UseErrorHandler(this IApplicationBuilder app)
            => app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}