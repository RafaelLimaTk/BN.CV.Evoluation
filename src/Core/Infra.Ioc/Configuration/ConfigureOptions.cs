using Cache;
using Infra.Ioc.Configuration.Swagger;
using Infra.Ioc.Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc.Configuration;
public static class ConfigureOptions
{
    public static void ConfigureApi(this IServiceCollection services, IConfiguration configuration, string xmlDocumentationName)
    {
        #region CORS
        services.AddCors(options =>
        {
            options.AddPolicy("CorsDevelopment", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        services.AddCors(options =>
        {
            options.AddPolicy("CorsProduction", builder =>
            {
                builder.AllowAnyOrigin();
            });
        });
        #endregion

        services.AddCacheModule(configuration);
        services.AddDependenceInjection(configuration);
        services.AddMediatR();
        services.AddMassTransitConsumer(configuration);
        services.AddVersioningConfig();
        services.AddSwaggerGenConfig(xmlDocumentationName);
    }
}
