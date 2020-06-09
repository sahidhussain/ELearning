using ELearning.Dto.V1.Request;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.API.SwaggerExamples.Request
{
    public class TitleRequestExample : IExamplesProvider<TitleRequest>
    {
        public TitleRequest GetExamples()
        {
            return new TitleRequest
            {
                Name="Mr.",
                IsActive = true
            };
        }
    }
}
