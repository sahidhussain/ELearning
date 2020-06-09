using ELearning.Dto.V1.Response;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.API.SwaggerExamples.Response
{
    public class TitleResponseExample : IExamplesProvider<TitleResponse>
    {
        public TitleResponse GetExamples()
        {
            return new TitleResponse
            {
                ID = 1,
                Name = "Mr.",
                IsActive = true
            };
        }
    }
}
