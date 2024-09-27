using Domain.Contracts.Base;
using Domain.Interfaces.Common.Mongo;
using Domain.Models;
using MediatR;

namespace Application.MediatR.UseCases.Commands;

public class DeleteOrganizationEntherpriseCommand : ContractIdBase, IRequest<bool>
{
}

public class DeleteOrganizationEntherpriseCommandHandler : IRequestHandler<DeleteOrganizationEntherpriseCommand, bool>
{
    private readonly IWriteRepository<OrganizationEntherpriseModel> _writeRepository;

    public DeleteOrganizationEntherpriseCommandHandler(IWriteRepository<OrganizationEntherpriseModel> writeRepository)
    {
        _writeRepository = writeRepository;
    }
    public async Task<bool> Handle(DeleteOrganizationEntherpriseCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id.ToString());

        return true;
    }
}
