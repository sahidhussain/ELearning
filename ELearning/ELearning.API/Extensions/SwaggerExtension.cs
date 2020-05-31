using ELearning.API.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ELearning.API.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "ELearning API", 
                    Version = "v1" 
                });
            });

        }

        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerOptions = new SwaggerOptions();

            configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint(swaggerOptions.UIEndPoint, swaggerOptions.Description);
            });
        }

    }
}
