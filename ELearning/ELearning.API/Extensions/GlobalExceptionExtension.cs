using ELearning.API.Helper;
using ELearning.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ELearning.API.Extensions
{
    public static class GlobalExceptionExtension
    {
        #region V1: Exception Extension
        public static void UseCustomExceptionExtension(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        await context.Response.WriteAsync(new ExceptionResponse()
                        {
                            Success = false,
                            StatusCode = context.Response.StatusCode,
                            Exceptions = new Exceptions()
                            {
                                ErrorMessage = ex.Error.Message,
                                InnerException = ex.Error.InnerException?.Message,
                                StackTrace = ex.Error.StackTrace,
                                ErrorPath = context.Request.Path
                            }
                        }.ToString());
                    }
                });
            });
        }
        #endregion

        #region V2: Exception Middleware
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
        #endregion
    }
}
