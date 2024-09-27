using Application.AutoMapperProfiles;
using Domain.Interfaces.Base;
using Domain.Interfaces.Common;
using Domain.Interfaces.Read;
using FluentMigrator.Runner;
using Infra.Data.Context;
using Infra.Data.Models;
using Infra.Data.Repositories.Base;
using Infra.Data.Repositories.Common;
using Infra.Data.Repositories.Read;
using Infra.Ioc.Configuration.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Infra.Ioc.Infraestructure;

public static class DependencyInjection
{
    public static void AddDependenceInjection(this IServiceCollection services, IConfiguration configuration)
    {
        #region ContainerDI
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureConsumerSwaggerOptions>();
        services.AddTransient<IEventBusInterface, EventBus>();
        #endregion

        #region ReadContext

        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            return new MongoClient(settings.ConnectionString);
        });

        services.AddScoped<IMongoDatabase>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(settings.DatabaseName);
        });

        services.AddScoped(typeof(Domain.Interfaces.Common.Mongo.IReadRepository<>), typeof(Data.Repositories.Common.Mongo.ReadRepository<>));
        services.AddScoped(typeof(Domain.Interfaces.Common.Mongo.IWriteRepository<>), typeof(Data.Repositories.Common.Mongo.WriteRepository<>));
        services.AddScoped<IOrganizationEntherpriseReadRepository, OrganizationEntherpriseReadRepository>();
        #endregion

        #region WriteContext
        services.AddDbContext<DbWriteContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DbWriteConnection"),
        b => b.MigrationsAssembly(typeof(DbWriteContext).Assembly.FullName)));

        services.AddScoped(typeof(Domain.Interfaces.Common.IWriteRepository<>), typeof(Data.Repositories.Common.WriteRepository<>));
        services.AddScoped<IOrganizationEntherpriseWriteRepository, OrganizationEntherpriseWriteRepository>();
        #endregion

        #region Migration
        services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("DbWriteConnection"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        #endregion

        services.AddAutoMapper(typeof(OrganizationEntherpriseProfile));
    }
}