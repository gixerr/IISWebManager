using System;

namespace IISWebManager.Application.Exceptions.Mapper
{
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}