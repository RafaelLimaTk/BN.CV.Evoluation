using Domain.Entities;
using Domain.Interfaces.Read;
using MediatR;

namespace Application.MediatR.UseCases.Commands;

public class SaveOrganizationEntherpriseCommand : OrganizationEntherprise, IRequest<OrganizationEntherprise>
{
}

public class SaveOrganizationEntherpriseCommandHandler : IRequestHandler<SaveOrganizationEntherpriseCommand, OrganizationEntherprise>
{
    private readonly IOrganizationEntherpriseWriteRepository _writeRepository;

    public SaveOrganizationEntherpriseCommandHandler(IOrganizationEntherpriseWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<OrganizationEntherprise> Handle(SaveOrganizationEntherpriseCommand request, CancellationToken cancellationToken)
    {
        var result = new OrganizationEntherprise();
        var entity = await _writeRepository.GetByIdAsNoTrackingAsync(request.Id);

        if(entity is null)
            result = await _writeRepository.AddAsync(request);
        else
            result = await _writeRepository.UpdateAsync(request);

        await _writeRepository.SaveChangesAsync();

        return result;
    }
}
