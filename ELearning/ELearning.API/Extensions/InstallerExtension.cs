using ELearning.IOC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ELearning.API.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(IInstaller).Assembly.ExportedTypes
                                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
