using ERP.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Services.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}