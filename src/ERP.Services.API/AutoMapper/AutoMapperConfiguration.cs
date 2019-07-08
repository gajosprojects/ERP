using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Services.API.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings(this IServiceCollection services)
        {
            if (services == null) throw new System.ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Startup));

            return new MapperConfiguration(configuration => {
                configuration.AddProfile(new DomainToViewModelMappingProfile());
                configuration.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}