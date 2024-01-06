using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Exceptions;
using Shared.Model;
using System.Net;

namespace API.Filters
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public class FilterException : IExceptionFilter
    {
        /// <summary>
        ///  <inheritdoc />
        /// </summary>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessException)
            {
                var businessException = context.Exception as BusinessException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                context.Result = new ObjectResult(new FilterErrorException
                (
                    businessException.Messages,
                    (int)HttpStatusCode.BadRequest,
                    businessException.InnerException
                ));
            }
            else if(context.Exception is InfraException)
            {
                var infraException = context.Exception as InfraException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Result = new ObjectResult(new FilterErrorException
                (
                    infraException.Message,
                    (int)HttpStatusCode.InternalServerError,
                    infraException.InnerException
                ));
            } else
            {
                var exception = context.Exception as Exception;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Result = new ObjectResult(new FilterErrorException
                (
                    exception.Message,
                    (int)HttpStatusCode.InternalServerError,
                    exception.InnerException
                ));
            }
        }
    }
}
