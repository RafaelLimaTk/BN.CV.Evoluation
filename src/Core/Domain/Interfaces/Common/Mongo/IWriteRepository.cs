using Domain.Base;
using System.Linq.Expressions;

namespace Domain.Interfaces.Common.Mongo;

public interface IWriteRepository<T> where T : class, IModelBaseId
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task<T> GetQuerable(Expression<Func<T, bool>> predicated);
    Task<IQueryable<T>> GetAllQuerable();
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity, string id);
    Task DeleteAsync(string id);
}
