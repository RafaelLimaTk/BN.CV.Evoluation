using Domain.Entities;
using Domain.Interfaces.Read;
using Infra.Data.Context;
using Infra.Data.Repositories.Common;

namespace Infra.Data.Repositories.Read;

public class OrganizationEntherpriseWriteRepository : WriteRepository<OrganizationEntherprise>, IOrganizationEntherpriseWriteRepository
{
    public OrganizationEntherpriseWriteRepository(DbWriteContext dbContext) : base(dbContext)
    { }
}
