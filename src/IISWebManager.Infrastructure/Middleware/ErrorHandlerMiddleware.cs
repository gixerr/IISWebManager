using System;
using System.Net;
using System.Threading.Tasks;
using IISWebManager.Application.Exceptions;
using IISWebManager.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ApplicationException = IISWebManager.Application.Exceptions.ApplicationException;

namespace IISWebManager.Infrastructure.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IExceptionToResponseMapper _exceptionToResponseMapper;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger,
            IExceptionToResponseMapper exceptionToResponseMapper)
        {
            _next = next;
            _logger = logger;
            _exceptionToResponseMapper = exceptionToResponseMapper;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var response = _exceptionToResponseMapper.Map(exception);
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) response.StatusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}