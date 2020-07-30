using System;
using System.Net;
using System.Threading.Tasks;
using Dictionary.Services.CustomExceptions;
using Dictionary.WebUi.Misc;
using Microsoft.AspNetCore.Http;

namespace Dictionary.WebUi.CustomMiddleware
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomValidationException ex)
            {
                await HandleCustomExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleCustomExceptionAsync(HttpContext httpContext, CustomValidationException ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            
            IResultSerializer resultSerializer = new ResultSerializer();
            string errorResult = resultSerializer.Serialize(new ErrorResult(ex));

            return httpContext.Response.WriteAsync(errorResult);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new StandardResult<Empty>
            {
                Error = exception.ToString()
            }.ToString());
        }
    }
}