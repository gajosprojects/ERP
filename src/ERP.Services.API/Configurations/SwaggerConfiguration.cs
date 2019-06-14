using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ERP.Services.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services) 
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ERP API",
                    Description = "ERP API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Gajos Projects", Email = "gajosprojects@gmail.com", Url = "" },
                    License = new License { Name = "." }
                });
            });
        }
    }
}