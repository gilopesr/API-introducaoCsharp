using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProdClient.Communication.Responses;
using ProdClient.Exceptions.ExceptionBase;

namespace ProdClient_API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProdClientException prodClientException)
            {
                context.HttpContext.Response.StatusCode = (int)prodClientException.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErrorMessagesJson(prodClientException.GetErrors()));
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

    private void ThrowUnkowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("erro desconhecido"));
        }
    }
}
