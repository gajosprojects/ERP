using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Services.API.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            Mapper.Initialize(autoMapperConfiguration =>
            {
                autoMapperConfiguration.AddProfile(new DomainToViewModelMappingProfile());
                autoMapperConfiguration.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}