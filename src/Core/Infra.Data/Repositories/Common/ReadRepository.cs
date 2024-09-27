using Domain.Entities.Base;
using Domain.Interfaces.Common;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Data.Repositories.Common;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase
{
    private readonly DbReadContext _dbContext;
    public readonly DbSet<T> _DbSet;
    public ReadRepository(DbReadContext dbContext)
    {
        _dbContext = dbContext;
        _DbSet = _dbContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
        =>  await _DbSet.FindAsync(id);

    public async Task<T?> GetByIdAsNoTrackingAsync(Guid id)
        => await _DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

    public async Task<T?> GetByPredicated(Expression<Func<T, bool>> predicated)
        => await _DbSet.Where(predicated).FirstOrDefaultAsync();

    public async Task<IEnumerable<T>> GetListByPredicated(Expression<Func<T, bool>> predicated)
        => await _DbSet.Where(predicated).ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _DbSet.ToListAsync();

    public async Task<bool> ExistsAsync(Guid id)
        => await _DbSet.AnyAsync(e => EF.Property<Guid>(e, "Id") == id);

    public IQueryable<T> GetAllQuerable()
        => _DbSet;   
    
    public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}
