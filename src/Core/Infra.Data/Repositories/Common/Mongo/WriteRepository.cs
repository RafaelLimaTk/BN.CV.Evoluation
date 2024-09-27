using Domain.Base;
using Domain.Interfaces.Common.Mongo;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Infra.Data.Repositories.Common.Mongo;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IModelBaseId
{
    private readonly IMongoCollection<T> _dbCollection;

    public WriteRepository(IMongoDatabase database)
    {
        _dbCollection = database.GetCollection<T>(typeof(T).Name.Replace("Model", ""));
    }

    public async Task<List<T>> GetAllAsync()
        => await _dbCollection.Find(entity => true).ToListAsync();

    public async Task<T> GetByIdAsync(string id)
        => await _dbCollection.Find(entity => entity.Id == id).FirstOrDefaultAsync();

    public async Task<T> GetQuerable(Expression<Func<T, bool>> predicated)
        => await _dbCollection.Find(predicated).FirstOrDefaultAsync();

    public async Task<IQueryable<T>> GetAllQuerable()
        => await Task.FromResult(_dbCollection.AsQueryable());

    public async Task CreateAsync(T entity)
    {
        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(T entity, string id)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
        await _dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
        var result = await _dbCollection.DeleteOneAsync(filter);

        if (result.DeletedCount == 0)
        {
            throw new Exception($"Documento com Id {id} não encontrado.");
        }
    }
}
