using Microsoft.OpenApi.Models;

namespace WebApp.Dockerize.MongoDbDriver._230;

using Microsoft.Extensions.DependencyInjection;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MongoDB Driver 2.30.0 API test",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "API Support",
                }
            });
            
            // Incluir comentarios XML si existen
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
        });
        return services;
    }
}