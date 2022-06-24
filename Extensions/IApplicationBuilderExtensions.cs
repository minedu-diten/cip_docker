using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace apiWeb.Extensions
{
    public static class IApplicationBuilderExtensions
    {

        public static void UseSwaggerDoc(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["Microservice"]);
            });
        }

        public static void UseAllCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }
    }
}