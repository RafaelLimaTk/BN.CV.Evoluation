using Application.Consumers.Common;
using Application.DTOs;
using Application.MediatR.UseCases;
using Application.MediatR.UseCases.Commands;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Consumers;

public class OrganizationEntherpriseConsumer : ConsumerBase<OrganizationEntherprise, OrganizationEntherpriseContract, OrganizationEntherpriseOrchestratorCommand, OrganizationEntherpriseDTO>
{
    public OrganizationEntherpriseConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
}

public class OrganizationEntherpriseDeleteConsumer : DeleteConsumerBase<OrganizationEntherprise, OrganizationEntherpriseDeleteContract, DeleteOrganizationEntherpriseCommand, bool>
{
    public OrganizationEntherpriseDeleteConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
}
