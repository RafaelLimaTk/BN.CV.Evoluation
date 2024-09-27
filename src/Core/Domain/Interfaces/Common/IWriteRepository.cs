using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Domain.Interfaces.Common;

public interface IWriteRepository<T> where T : class, IEntityBase
{
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetByIdAsNoTrackingAsync(Guid id);
    Task<T> GetByPredicated(Expression<Func<T, bool>> predicated);
    Task<IEnumerable<T>> GetListByPredicated(Expression<Func<T, bool>> predicated);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetAllQuerable();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> ExistsAsync(Guid id);
    Task SaveChangesAsync();
}
