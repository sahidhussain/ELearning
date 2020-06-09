using ELearning.Dto.V1.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ELearning.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                var errorResponse = new ErrorResponse();
                errorResponse.Success = false;
                errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;

                foreach (var error in errorsInModelState)
                {
                    foreach (var errorMessage in error.Value)
                    {
                        var errorModel = new ErrorModel()
                        {
                            Field = error.Key,
                            Message = errorMessage
                        };
                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();

        }
    }
}
