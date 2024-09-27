using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infra.Ioc.Configuration;

public static class GlobalizationConfig
{
    public static WebApplication UseGlobalizationConfig(this WebApplication app)
    {
        var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(localizationOptions.Value);

        return app;
    }

    public static WebApplicationBuilder AddGlobalizationConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var suportedCultures = new[] { "pt-BR", "en-US" };
            options.SetDefaultCulture(suportedCultures[0])
            .AddSupportedCultures(suportedCultures)
            .AddSupportedUICultures(suportedCultures);
        });

        return builder;
    }
}
