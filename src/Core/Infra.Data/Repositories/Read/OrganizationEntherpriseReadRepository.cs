using Domain.Interfaces.Read;
using Domain.Models;
using Infra.Data.Repositories.Common.Mongo;
using MongoDB.Driver;

namespace Infra.Data.Repositories.Read;

public class OrganizationEntherpriseReadRepository : ReadRepository<OrganizationEntherpriseModel>, IOrganizationEntherpriseReadRepository
{
    public OrganizationEntherpriseReadRepository(IMongoDatabase database) : base(database)
    {
    }
}
