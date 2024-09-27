using Application.DTOs;
using AutoMapper;
using Domain.Contracts;
using Domain.Interfaces.Common.Mongo;
using Domain.Models;
using MediatR;

namespace Application.MediatR.UseCases;

public class OrganizationEntherpriseOrchestratorCommand : OrganizationEntherpriseContract, IRequest<OrganizationEntherpriseDTO>
{
}

public class OrganizationEntherpriseOrchestratorCommandHandler : IRequestHandler<OrganizationEntherpriseOrchestratorCommand, OrganizationEntherpriseDTO>
{
    private readonly IWriteRepository<OrganizationEntherpriseModel> _writeRepository;
    private readonly IMapper _mapper;

    public OrganizationEntherpriseOrchestratorCommandHandler(IWriteRepository<OrganizationEntherpriseModel> writeRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
    }
    public async Task<OrganizationEntherpriseDTO> Handle(OrganizationEntherpriseOrchestratorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _writeRepository.GetByIdAsync(request.Id.ToString());

        if (entity == null)
            await _writeRepository.CreateAsync(_mapper.Map<OrganizationEntherpriseModel>(request));
        else
            await _writeRepository.UpdateAsync(_mapper.Map<OrganizationEntherpriseModel>(request), request.Id.ToString());

        var result = await _writeRepository.GetByIdAsync(request.Id.ToString());
        return _mapper.Map<OrganizationEntherpriseDTO>(result);
    }
}
