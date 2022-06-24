using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace apiWeb.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddSwaggerDoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = configuration["Microservice"],
                    TermsOfService = new Uri("https://cursos-cip.pe/docker"),
                    Contact = new OpenApiContact
                    {
                        Name = "CURSO DOCKER REGISTRO PARTICIPANTES",
                        Email = string.Empty,
                        Url = new Uri("https://cursos-cip.pe/contact"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://cursos-cip.pe/license"),
                    }
                });
            });
        }
    }
}