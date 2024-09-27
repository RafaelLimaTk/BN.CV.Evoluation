using Application.Common.MediatR.Queries;
using Application.Common.Queries;
using Common.MediatR.Commands;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc.Infraestructure;

public static class DependencyInjectionMediatR
{
    public static IServiceCollection AddMediatR(this IServiceCollection service)
    {
        #region Mediator
        var myHandlers = AppDomain.CurrentDomain.Load("Application");
        service.AddMediatR(myHandlers);

        service.AddScoped<IRequestHandler<GetAllQuery<OrganizationEntherpriseModel>, IEnumerable<OrganizationEntherpriseModel>>, GetAllQueryHandler<OrganizationEntherpriseModel>>();
        service.AddScoped<IRequestHandler<GetByIdQuery<OrganizationEntherpriseModel>, OrganizationEntherpriseModel>, GetByIdQueryHandler<OrganizationEntherpriseModel>>();
        service.AddScoped<IRequestHandler<GetQuerablePredicated<OrganizationEntherpriseModel>, IQueryable<OrganizationEntherpriseModel>>, GetQuerablePredicatedHandler<OrganizationEntherpriseModel>>();
        service.AddScoped<IRequestHandler<PutEntityCommand<OrganizationEntherprise>, OrganizationEntherprise>, PutEntityCommandHandler<OrganizationEntherprise>>();
        service.AddScoped<IRequestHandler<DeleteEntityCommand<OrganizationEntherprise>, bool>, DeleteEntityCommandHandler<OrganizationEntherprise>>();
        #endregion

        return service;
    }
}
