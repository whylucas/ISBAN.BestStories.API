using Flurl.Http;
using ISBAN.BestStories.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ISBAN.BestStories.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is FlurlHttpException)
            {
                var errorResponse = new ErrorResponse { Status = 500, Message = $"Error calling HackerNewsAPI: {context.Exception.Message}" };
                context.Result = new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            else if (context.Exception is FlurlHttpTimeoutException)
            {
                var errorResponse = new ErrorResponse { Status = 504, Message = $"Timeout calling HackerNewsAPI: {context.Exception.Message}" };
                context.Result = new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status504GatewayTimeout};
            }
            else
            {
                var errorResponse = new ErrorResponse { Status = 500, Message = context.Exception.Message };
                context.Result = new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
