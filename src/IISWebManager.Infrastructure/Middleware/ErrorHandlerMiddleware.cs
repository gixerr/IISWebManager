using System;
using System.Net;
using System.Threading.Tasks;
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

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger )
        {
            _next = next;
            _logger = logger;
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

        private static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            string errorCode;
            HttpStatusCode statusCode;
            string message;
            switch (exception)
            {
                case DomainException ex :
                    errorCode = ex.Code;
                    message = ex.Message;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ApplicationException ex :
                    errorCode = ex.Code;
                    message = ex.Message;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    errorCode = "Error";
                    message = "Something went wrong.";
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            var response = new {code = errorCode, message = message};
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}