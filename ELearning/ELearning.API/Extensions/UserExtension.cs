using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.API.Extensions
{
    public static class UserExtension
    {
        public static string GetUserId(this HttpContext context)
        {
            if (context.User == null)
            {
                return string.Empty;
            }

            return context.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}
