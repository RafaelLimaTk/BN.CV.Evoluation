using Application.Common.MediatR.Queries;
using Application.DTOs;
using Application.MediatR.UseCases.Commands;
using AutoMapper;
using Controllers.Base;
using Domain.Contracts;
using Domain.Interfaces.Common;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Interface = Domain.Interfaces.Common.Mongo;

namespace BN.CV.Evaluation.Api.Controllers.V1;

[ApiVersion("1.0")]
public class OrganizationEntherpriseController : MainController
{
    private readonly ICache _cache;
    private readonly Interface.IReadRepository<OrganizationEntherpriseModel> _readRepository;
    private readonly IEventBusInterface _eventBusInterface;

    public OrganizationEntherpriseController(IMapper mapper,
                                             IMediator mediator,
                                             ICache cache,
                                             Interface.IReadRepository<OrganizationEntherpriseModel> readRepository,
                                             IEventBusInterface eventBusInterface) : base(mapper, mediator)
    {
        _cache = cache;
        _readRepository = readRepository;
        _eventBusInterface = eventBusInterface;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        if (await _cache.ExitsAsync("organizationsEntherprise"))
            return CustomResponse(await _cache.GetObjectAsync<IEnumerable<OrganizationEntherpriseModel>>("organizationsEntherprise"));
        else
        {
            var response = await _mediator.Send(new GetAllQuery<OrganizationEntherpriseModel>());
            if (response.Any())
                await _cache.AddToCacheAsync("organizationsEntherprise", response, 60);
            return CustomResponse(response);
        }
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _mediator.Send(new GetByIdQuery<OrganizationEntherpriseModel> { Id = id.ToString() });

        return CustomResponse(_mapper.Map<OrganizationEntherpriseDTO>(response));
    }

    [HttpPost("")]
    public async Task<IActionResult> Save([FromBody] SaveOrganizationEntherpriseCommand request)
    {
        var response = await _mediator.Send(request);

        await _eventBusInterface.PublishMessage(_mapper.Map<OrganizationEntherpriseContract>(response));
        await _cache.RemoveFromCacheAsync($"organizationsEntherprise");

        return CustomResponse(_mapper.Map<OrganizationEntherpriseModel>(response));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var response = await _mediator.Send(new DeleteOrganizationEntherpriseCommand { Id = id });
        await _eventBusInterface.PublishMessage(new OrganizationEntherpriseDeleteContract { Id = id });
        await _cache.RemoveFromCacheAsync($"organizationsEntherprise");
        return CustomResponse($"{id} Deleted");
    }
}
