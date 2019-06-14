using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Services.API.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings(this IServiceCollection services)
        {
            return new MapperConfiguration(configuration => {
                configuration.AddProfile(new DomainToViewModelMappingProfile());
                configuration.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}