using ELearning.API.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ELearning.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ExceptionResponse()
            {
                Success = false,
                StatusCode = context.Response.StatusCode,
                Exceptions = new Exceptions()
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException?.Message,
                    StackTrace = ex.StackTrace,
                    ErrorPath = context.Request.Path
                }
            }.ToString());
        }
    }
}
