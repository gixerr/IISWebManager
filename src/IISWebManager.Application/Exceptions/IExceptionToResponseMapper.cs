using System;

namespace IISWebManager.Application.Exceptions
{
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}