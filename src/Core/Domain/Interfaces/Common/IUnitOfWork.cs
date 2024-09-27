using Domain.Interfaces.Read;

namespace Domain.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    public IOrganizationEntherpriseReadRepository OrganizationEntherprises { get; set; }

    Task SaveChangesAsync();
    void Atach<T>(T entity) where T : class;
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
