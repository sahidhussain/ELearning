using ELearning.Infrastructure;
using ELearning.Infrastructure.Implementation;
using ELearning.Services;
using ELearning.Services.Services;
using ELearning.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.IOC
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITitleServices, TitleRepository>();
            services.AddTransient<IAccountServices, AccountRepository>();
        }
    }
}
