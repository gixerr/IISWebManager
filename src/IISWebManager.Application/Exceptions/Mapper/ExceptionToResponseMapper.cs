using System;
using System.Net;
using IISWebManager.Core.Exceptions;

namespace IISWebManager.Application.Exceptions.Mapper
{
    public sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException ex => new ExceptionResponse(new {code = ex.Code, message = ex.Message},
                    HttpStatusCode.BadRequest),
                ApplicationException ex => new ExceptionResponse(new {code = ex.Code, message = ex.Message},
                    HttpStatusCode.BadRequest),
                UnauthorizedAccessException ex => new ExceptionResponse(
                    new
                    {
                        code = "unauthorized_access",
                        message = "Cannot read configuration file due to insufficient permissions. Forbidden access to Server Manager."
                    }, HttpStatusCode.Unauthorized),
                _ => new ExceptionResponse(new {code = "Error", message = "Something went wrong."},
                    HttpStatusCode.BadRequest)
            };
    }
}