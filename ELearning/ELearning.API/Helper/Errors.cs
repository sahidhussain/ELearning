using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace ELearning.API.Helper
{
    public static class Errors
    {
        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
        {
            foreach (var e in identityResult.Errors)
            {
                modelState.AddModelError(e.Code, e.Description);
            }

            return modelState;
        }

        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            modelState.AddModelError(code, description);
            return modelState;
        }
    }
}
