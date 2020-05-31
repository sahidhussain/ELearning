using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.IOC
{
   public  interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
