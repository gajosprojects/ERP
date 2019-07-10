using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

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
                    Description = "Sistema de gestão que permite acesso fácil, integrado e confiável aos dados de uma empresa. A partir dos dados levantados por um ERP, é possível fazer diagnósticos aprofundados sobre as medidas necessárias para reduzir custos e aumentar a produtividade."
                });

                s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
        }
    }
}