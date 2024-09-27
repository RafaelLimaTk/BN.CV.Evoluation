using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using RS = Resources.Common;

namespace Infra.Ioc.Configuration.Swagger;

public class ConfigureConsumerSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiVersionDescriptionProvider provider;

    public ConfigureConsumerSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;



    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = RS.SWAGGER_PAGE_LBL_TITLE,
            Version = description.ApiVersion.ToString(),
            Description = RS.SWAGGER_PAGE_LBL_DESCRIPTION,
            Contact = new OpenApiContact() { Name = "Rafael Lima", Email = "rafamano123.rl@gmail.com" },
            TermsOfService = new Uri("https://opensource.org/licenses/MIT"),
            License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };

        if (description.IsDeprecated)
        {
            info.Description += RS.SWAGGER_PAGE_LBL_VERSION_OBSOLETE;
        }

        return info;
    }
}
