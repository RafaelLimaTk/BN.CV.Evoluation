using Infra.Data.Context;
using Infra.Ioc.Configuration;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.ConfigureApi(builder.Configuration, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<DbWriteContext>();
dbContext.Database.Migrate();

app.ConfigureApp(builder.Configuration);

var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.Run();
