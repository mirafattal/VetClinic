using Microsoft.AspNetCore.Mvc.Filters;
using Vet_BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound
            };


            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            })
            {
                StatusCode = statusCode
            };
        }

    }
}
