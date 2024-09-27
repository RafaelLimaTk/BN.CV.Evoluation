using Domain.Extensions;
using Infra.Ioc.Configuration.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infra.Ioc.Configuration;
public static class ConfigureAppOptions
{
    public static WebApplication ConfigureApp(this WebApplication app, IConfiguration configuration)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCors("CorsDevelopment");
        }
        else if (app.Environment.IsProduction())
        {
            app.UseCors("CorsProduction");
            //app.UseHsts();
        }
        app.UseApiVersioning();

        app.UseMiddleware<SwaggerAuthorizeMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();

        app.MapControllers();
        //app.UseHttpsRedirection();

        app.UseAuthorization();

        return app;
    }
}
