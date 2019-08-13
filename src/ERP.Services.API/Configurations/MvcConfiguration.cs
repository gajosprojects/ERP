using ERP.Infra.CrossCutting.Identity.Authorization;
using ERP.Infra.CrossCutting.Identity.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace ERP.Services.API.Configurations
{
    public static class MvcConfiguration
    {
        public static void AddMvcSecurity(this IServiceCollection services, IConfigurationRoot configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var tokenConfigurations = new TokenDescription();
            new ConfigureFromConfigurationOptions<TokenDescription>(configuration.GetSection("JwtOptions")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddCors();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = false;
                bearerOptions.SaveToken = true;

                var paramsValidation = bearerOptions.TokenValidationParameters;

                paramsValidation.IssuerSigningKey = SigningCredentialsConfiguration.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                paramsValidation.ValidateIssuer = true;
                paramsValidation.ValidateAudience = true;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SaveGrupoEmpresarial", policy => policy.RequireClaim("Grupo Empresarial", "Save"));
                options.AddPolicy("UpdateGrupoEmpresarial", policy => policy.RequireClaim("Grupo Empresarial", "Update"));
                options.AddPolicy("DeleteGrupoEmpresarial", policy => policy.RequireClaim("Grupo Empresarial", "Delete"));
                options.AddPolicy("ViewGrupoEmpresarial", policy => policy.RequireClaim("Grupo Empresarial", "View"));

                options.AddPolicy("SaveCnae", policy => policy.RequireClaim("Cnae", "Save"));
                options.AddPolicy("UpdateCnae", policy => policy.RequireClaim("Cnae", "Update"));
                options.AddPolicy("DeleteCnae", policy => policy.RequireClaim("Cnae", "Delete"));
                options.AddPolicy("ViewCnae", policy => policy.RequireClaim("Cnae", "View"));

                options.AddPolicy("SaveEmpresa", policy => policy.RequireClaim("Empresa", "Save"));
                options.AddPolicy("UpdateEmpresa", policy => policy.RequireClaim("Empresa", "Update"));
                options.AddPolicy("DeleteEmpresa", policy => policy.RequireClaim("Empresa", "Delete"));
                options.AddPolicy("ViewEmpresa", policy => policy.RequireClaim("Empresa", "View"));

                options.AddPolicy("SaveEstabelecimento", policy => policy.RequireClaim("Estabelecimento", "Save"));
                options.AddPolicy("UpdateEstabelecimento", policy => policy.RequireClaim("Estabelecimento", "Update"));
                options.AddPolicy("DeleteEstabelecimento", policy => policy.RequireClaim("Estabelecimento", "Delete"));
                options.AddPolicy("ViewEstabelecimento", policy => policy.RequireClaim("Estabelecimento", "View"));

                options.AddPolicy("Bearer", new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            });
        }
    }
}
